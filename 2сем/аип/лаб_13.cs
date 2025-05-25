using System;
using System.Collections.Generic;
using System.Linq;
class Supplier
{
    public int Id;
    public string Name;
    public string Phone;
}
class Product
{
    public int Id;
    public string Name;
}
class ProductMovement
{
    public int ProductId;
    public int SupplierId;
    public string Type;
    public DateTime Date;
    public int Number;
    public int Price;
}
class Program
{
    static List<Supplier> suppliers =
    [
        new Supplier { Id = 1, Name = "ООО ТехноПоставка", Phone = "123-456" },
        new Supplier { Id = 2, Name = "ИП Иванов", Phone = "987-654" }
    ];
    static List<Product> products =
    [
        new Product { Id = 1, Name = "Ноутбук" },
        new Product { Id = 2, Name = "Монитор" },
        new Product { Id = 3, Name = "Клавиатура" }
    ];
    static List<ProductMovement> movements =
    [
        new ProductMovement { ProductId = 1, SupplierId = 1, Type = "in", Date = new DateTime(2025, 1, 10), Number = 5, Price = 50000 },
        new ProductMovement { ProductId = 1, SupplierId = 1, Type = "out", Date = new DateTime(2025, 1, 12), Number = 2, Price = 60000 },
        new ProductMovement { ProductId = 2, SupplierId = 2, Type = "in", Date = new DateTime(2025, 1, 15), Number = 3, Price = 25000 }
    ];
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. остатки товаров\n2. поставки по поставщикам\n3. продажи по датам\n4. выход");
            Console.Write("выберите действие: ");
            switch (Console.ReadLine())
            {
                case "1": Remains(); break;
                case "2": Supplies(); break;
                case "3": Sales(); break;
                case "4": return;
            }
        }
    }
    static void Remains()
    {
        Console.WriteLine("\nОтчёт об остатках товаров на складе:");
        foreach (var product in products)
        {
            var IN = movements
                .Where(m => m.ProductId == product.Id && m.Type == "in")
                .Sum(m => m.Number);
            var OUT = movements
                .Where(m => m.ProductId == product.Id && m.Type == "out")
                .Sum(m => m.Number);
            var remains = IN - OUT;
            Console.WriteLine($"{product.Name}: {remains} шт.");
        }
    }
    static void Supplies()
    {
        Console.WriteLine("\nпоставки по поставщикам:");
        var supplies = movements
            .Where(m => m.Type == "in")
            .GroupBy(m => m.SupplierId);
        foreach (var supplierGroup in supplies)
        {
            var supplier = suppliers.First(s => s.Id == supplierGroup.Key);
            Console.WriteLine($"\nпоставщик: {supplier.Name} (тел. {supplier.Phone})");
            Console.WriteLine("товары:");
            foreach (var supply in supplierGroup)
            {
                var product = products.First(p => p.Id == supply.ProductId);
                Console.WriteLine($"- {product.Name}: {supply.Number} шт. по цене {supply.Price} руб.");
            }
        }
    }
    static void Sales()
    {
        Console.WriteLine("\nпродажи по датам:");
        var sales = movements.Where(m => m.Type == "out");
        var salesByDate = sales.GroupBy(s => s.Date);
        foreach (var dateGroup in salesByDate.OrderBy(d => d.Key))
        {
            Console.WriteLine($"\nдата: {dateGroup.Key:dd.MM.yyyy}");
            Console.WriteLine("проданные товары:");
            foreach (var sale in dateGroup)
            {
                var product = products.First(p => p.Id == sale.ProductId);
                var totalAmount = sale.Number * sale.Price;
                Console.WriteLine($"- {product.Name}: {sale.Number} шт. на сумму {totalAmount} руб.");
            }
        }
    }
}

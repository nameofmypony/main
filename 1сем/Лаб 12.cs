using System;
class Train
{
    public int number;
    public string from;
    public string to;
    public DateTime time;
}
class Station
{
    public string name;
    public Train[] trains;
}
class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Train[] array = new Train[3];
        Station station = new Station { name = "имя станции", trains = array };
        int choice;
        do
        {
            Console.WriteLine("1 - ввести данные");
            Console.WriteLine("2 - вывести поезда с заданным пунктом назначения");
            Console.WriteLine("3 - вывести поезда, отправляющиеся после заданного времени");
            Console.WriteLine("4 - выйти");
            Console.Write("выберите действие (1-4): ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("введите данные о поездах:");
                    array = new Train[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("поезд " + (i + 1));
                        array[i] = new Train();
                        Console.Write("введите номер поезда: ");
                        array[i].number = int.Parse(Console.ReadLine());
                        Console.Write("введите название пункта отправления: ");
                        array[i].from = Console.ReadLine();
                        Console.Write("введите название пункта назначения: ");
                        array[i].to = Console.ReadLine();
                        Console.Write("введите время отправления (чч:мм): ");
                        array[i].time = DateTime.Parse(Console.ReadLine());
                    }
                    station.trains = array;
                    break;
                case 2:
                    Console.Write("введите название пункта назначения: ");
                    string destination = Console.ReadLine();
                    foreach (var train in station.trains)
                    {
                        if (train.to == destination)
                        {
                            Console.WriteLine("поезд " + train.number + " отправляется в пункт назначения " + destination);
                        }
                    }
                    break;
                case 3:
                    Console.Write("введите время отправления (чч:мм): ");
                    string inputtime = Console.ReadLine();
                    DateTime time = DateTime.Parse(inputtime);
                    foreach (var train in station.trains)
                    {
                        if (train.time > time)
                        {
                            Console.WriteLine("поезд " + train.number + " отправляется после " + time);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("выход");
                    break;
                default:
                    Console.WriteLine("ошибка");
                    break;
            }
        } while (choice != 4);
    }
}

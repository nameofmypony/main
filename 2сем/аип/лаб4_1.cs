using System;
class Program
{
    static void Main()
    {
        bool correct = true;
        string input = Console.ReadLine();
        string[] split = input.Split(' ');
        Stack<double> numbers = new Stack<double>();
        foreach (string a in split)
        {
            if (double.TryParse(a, out double number))
            {
                numbers.Push(number);
            }
            else if (a == "+")
            {
                if (numbers.TryPop(out double x))
                {
                    if (numbers.TryPop(out double y))
                    {
                        numbers.Push(y + x);
                    }
                    else
                    {
                        correct = false;
                        break;
                    }
                }
                else
                {
                    correct = false;
                    break;
                }
            }
            else if (a == "-")
            {
                if (numbers.TryPop(out double x))
                {
                    if (numbers.TryPop(out double y))
                    {
                        numbers.Push(y - x);
                    }
                    else
                    {
                        correct = false;
                        break;
                    }
                }
                else
                {
                    correct = false;
                    break;
                }
            }
            else if (a == "*")
            {
                if (numbers.TryPop(out double x))
                {
                    if (numbers.TryPop(out double y))
                    {
                        numbers.Push(y * x);
                    }
                    else
                    {
                        correct = false;
                        break;
                    }
                }
                else
                {
                    correct = false;
                    break;
                }
            }
            else if (a == "/")
            {
                if (numbers.TryPop(out double x))
                {
                    if (numbers.TryPop(out double y))
                    {
                        if (x != 0) numbers.Push(y / x);
                        else
                        {
                            correct = false; // делить на 0 нельзя
                            break;
                        }
                    }
                    else
                    {
                        correct = false;
                        break;
                    }
                }
                else
                {
                    correct = false;
                    break;
                }
            }
            else
            {
                correct = false; // если элемент строки ни число, ни одна из операций, то ошибка
                break;
            }
        }
        if (numbers.TryPop(out double answer)) // извлекаем ответ, если извлекать нечего, то ошибка
        {
            if (numbers.TryPop(out double c)) correct = false; // если после извлечения ответа в стеке что-то есть, то ошибка
        }
        else correct = false;
        if (correct) Console.WriteLine(answer);
        else Console.WriteLine("error");
    }
}

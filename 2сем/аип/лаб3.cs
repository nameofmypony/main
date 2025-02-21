using System;
class Program
{
    static void Main()
    {
        bool result = true;
        string expression = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        foreach (char symbol in expression)
        {
            if ((symbol == '(') || (symbol == '[') || (symbol == '{'))
            {
                stack.Push(symbol);
            }
            else if ((symbol == ')') || (symbol == ']') || (symbol == '}'))
            {
                if (stack.TryPeek(out char a))
                {
                    if ((a == '(') && (symbol == ')') || (a == '[') && (symbol == ']') || (a == '{') && (symbol == '}'))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    result = false;
                    break;
                }
            }
        }
        if (stack.TryPeek(out char b)) result = false;
        if (result) Console.WriteLine("brackets placed correctly");
        else Console.WriteLine("brackets placed incorrectly");
    }
}

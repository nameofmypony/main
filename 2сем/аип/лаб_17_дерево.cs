using System;
using System.Runtime.InteropServices;
public unsafe struct StudentNode
{
    public int Id;
    public fixed char FullName[256];
    public StudentNode* Left;
    public StudentNode* Right;
}
public unsafe class StudentTree : IDisposable
{
    private StudentNode* root;
    public void Add(int id, string fullName)
    {
        StudentNode* newNode = (StudentNode*)NativeMemory.Alloc((nuint)sizeof(StudentNode));
        newNode->Id = id;
        newNode->Left = null;
        newNode->Right = null;
        char* namePtr = newNode->FullName;
        {
            int len = Math.Min(fullName.Length, 255);
            for (int i = 0; i < len; i++)
                namePtr[i] = fullName[i];
            namePtr[len] = '\0';
        }
        if (root == null)
        {
            root = newNode;
            return;
        }
        StudentNode* current = root;
        while (true)
        {
            StudentNode** nextPtr = (id < current->Id)
                ? &current->Left
                : &current->Right;
            if (*nextPtr == null)
            {
                *nextPtr = newNode;
                return;
            }
            current = *nextPtr;
        }
    }
    public void PrintTree()
    {
        Console.WriteLine("дерево:");
        PrintRecursive(root, 0);
    }
    private void PrintRecursive(StudentNode* node, int depth)
    {
        if (node == null) return;
        PrintRecursive(node->Left, depth + 1);
        char* namePtr = node->FullName;
        {
            string name = new(namePtr);
            Console.WriteLine($"{new string(' ', depth * 2)}[{node->Id}] {name}");
        }
        PrintRecursive(node->Right, depth + 1);
    }
    public void Dispose()
    {
        FreeNodeRecursive(root);
    }
    private void FreeNodeRecursive(StudentNode* node)
    {
        if (node == null) return;
        FreeNodeRecursive(node->Left);
        FreeNodeRecursive(node->Right);
        NativeMemory.Free(node);
    }
}
public unsafe class Program
{
    static void Main()
    {
        using var tree = new StudentTree();
        tree.Add(10, "Иванов Иван");
        tree.Add(5, "Петрова Анна");
        tree.Add(15, "Сидоров Алексей");
        tree.PrintTree();
    }
}

using System;
using System.Collections.Generic;

class Program
{
    
    public class ToDoItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoItem(string name)
        {
            Name = name;
            IsCompleted = false;
        }
    }

    static List<ToDoItem> toDoList = new List<ToDoItem>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати справу");
            Console.WriteLine("2. Показати всі справи");
            Console.WriteLine("3. Позначити справу як виконану");
            Console.WriteLine("4. Видалити справу");
            Console.WriteLine("5. Вийти");

            Console.Write("\nВиберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddToDo();
                    break;
                case "2":
                    ShowToDos();
                    break;
                case "3":
                    MarkAsCompleted();
                    break;
                case "4":
                    DeleteToDo();
                    break;
                case "5":
                    Console.WriteLine("Вихід з програми...");
                    return;
                default:
                    Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                    break;
            }
        }
    }

    // Додавання нової справи
    static void AddToDo()
    {
        Console.Write("Введіть назву справи: ");
        string name = Console.ReadLine();
        toDoList.Add(new ToDoItem(name));
        Console.WriteLine("Справу додано!");
    }

    // Виведення всіх справ
    static void ShowToDos()
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.WriteLine("\nСписок справ:");
        for (int i = 0; i < toDoList.Count; i++)
        {
            string status = toDoList[i].IsCompleted ? "Виконано" : "Не виконано";
            Console.WriteLine($"{i + 1}. {toDoList[i].Name} - {status}");
        }
    }

    // Позначення справи як виконаної
    static void MarkAsCompleted()
    {
        Console.Write("Введіть номер справи для позначення як виконаної: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= toDoList.Count)
        {
            toDoList[index - 1].IsCompleted = true;
            Console.WriteLine("Справу позначено як виконану!");
        }
        else
        {
            Console.WriteLine("Невірний номер справи.");
        }
    }

    // Видалення справи
    static void DeleteToDo()
    {
        Console.Write("Введіть номер справи для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= toDoList.Count)
        {
            toDoList.RemoveAt(index - 1);
            Console.WriteLine("Справу видалено!");
        }
        else
        {
            Console.WriteLine("Невірний номер справи.");
        }
    }
}

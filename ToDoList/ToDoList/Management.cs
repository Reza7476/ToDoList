using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList;
public class Management : IManagement
{

    private List<Schadule> schadules = new();

    public void GetSchadules()
    {

        var doList = schadules.OrderBy(_ => _.DateToDo).ToList();

        if (doList.Count > 0)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var toDo in doList)
            {
                Console.WriteLine($"title :{toDo.Title}  priority: {toDo.Priority}   date: {toDo.DateToDo} ");
            }
            Console.ResetColor();
        }
        else
        {
            throw new Exception("An unregistered task ");
        }
    }



    public void CreateSchadule(string title, DateTime dateTodo, Priority priority)
    {
        if (priority == Priority.high)
        {
            HighPriority highPriority = new(title, dateTodo);
            schadules.Add(highPriority);
            Success();
        }
        else if (priority == Priority.low)
        {
            LowPirority lowPriority = new(title, dateTodo);
            schadules.Add(lowPriority);
            Success();
        }
        else
        {
            MediumPirority mediumPriority = new(title, dateTodo);
            schadules.Add(mediumPriority);
            Success();
        }
    }

    public string GetString(string message)
    {
        Console.WriteLine(message);
        var value = Console.ReadLine()!;
        return value;
    }




    public DateTime GetDate(string message)
    {
        Console.WriteLine(message);
        var value = DateTime.Parse(Console.ReadLine()!);

        return value;
    }


    public int GetPriority()
    {
        Console.WriteLine($"choice your priority\n" +
            $"\t 1: {Priority.high}\n" +
            $"\t 2: {Priority.medium}\n" +
            $"\t 3: {Priority.low}");

        var value = int.Parse(Console.ReadLine()!);
        return value;
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public void Success()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"------------\nSuccess\n------------");
        Console.ResetColor();
    }
    public int Run()
    {
        Console.WriteLine($"1: Create schadule\n" +
            $"2: Display all schadules\n" +
            $"3: Display schadule on special date\n" +
            $"4: Display schadule on special day with special priority\n" +
            $"0:Exit");
        var value = int.Parse(Console.ReadLine()!);
        return value;
    }

    public void GetSchaduleByDate(DateTime date)
    {
        var doList = schadules.Where(_ => _.DateToDo == date).ToList();

        if (doList.Count > 0)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var toDo in doList)
            {
                Console.WriteLine($"\ttitle :{toDo.Title}  priority: {toDo.Priority}   date: {toDo.DateToDo} ");
            }
            Console.ResetColor();
        }
        else
        {
            throw new Exception("No task has been specified on this day ");
        }

    }

    public void GetSchadulesByPrioriytOnSpecialday(Priority priority, DateTime day)
    {
        var doList = schadules.Where(s => s.DateToDo == day && s.Priority == priority).OrderByDescending(s => s.Priority).ToList();

        if (doList.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var toDo in doList)
            {
                Console.WriteLine($"\ttitle :{toDo.Title}  priority: {toDo.Priority}   date: {toDo.DateToDo} ");
            }
            Console.ResetColor();
        }
        else
        {
            throw new Exception("No task has been specified on this day ");
        }
    }
}

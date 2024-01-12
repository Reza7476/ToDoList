using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList;
public abstract class Schadule
{
    public Schadule(string title, DateTime dateToDo, Priority priority)
    {
        Title = title;
        DateToDo = dateToDo;
        Priority = priority;
    }

    public string Title { get; private set; }

    public DateTime DateToDo { get; private set; }

    public Priority Priority { get; private set; }
}



public enum Priority
{
    high,
    medium,
    low,
    none
}

public class HighPriority : Schadule
{
    public HighPriority(string title, DateTime dateToDo) : base(title, dateToDo, Priority.high)
    {

    }
}

public class LowPirority : Schadule
{
    public LowPirority(string title, DateTime dateToDo) : base(title, dateToDo, Priority.low)
    {
    }
}
public class MediumPirority : Schadule
{

    public MediumPirority(string title, DateTime dateToDo) : base(title, dateToDo, Priority.medium)
    {
    }

}


public interface IManagement
{
    void GetSchadules();

    void GetSchaduleByDate(DateTime date);

    void GetSchadulesByPrioriytOnSpecialday(Priority priority, DateTime day);
}
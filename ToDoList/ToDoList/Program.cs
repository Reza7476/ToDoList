
using ToDoList;

Management management = new Management();

while (true)
{

    try
    {
        int exe = management.Run();
        switch (exe)
        {
            case 0:
                {
                    Environment.Exit(0);
                    break;
                }
            case 1:
                {
                    var PriorityToDo = Priority.none; ;
                    var title = management.GetString("enter title");
                    var dateToDo = management.GetDate("enter date to Do");
                    var priority = management.GetPriority();

                    if (priority == 1)
                    {
                        PriorityToDo = Priority.high;
                    }
                    else if (priority == 2)
                    {
                        PriorityToDo = Priority.medium;
                    }
                    else if (priority == 3)
                    {
                        PriorityToDo = Priority.low;
                    }
                    else
                    {
                        break;
                    }
                    management.CreateSchadule(title, dateToDo, PriorityToDo);

                    break;
                }
            case 2:
                {
                    management.GetSchadules();
                    break;
                }
            case 3:
                {
                    var date = management.GetDate("enter date");
                    management.GetSchaduleByDate(date);

                    break;
                }
            case 4:
                {

                    var PriorityToDo = Priority.none; ;
                    var date = management.GetDate("enter date");
                    var priority = management.GetPriority();
                    if (priority == 1)
                    {
                        PriorityToDo = Priority.high;
                    }
                    else if (priority == 2)
                    {
                        PriorityToDo = Priority.medium;
                    }
                    else if (priority == 3)
                    {
                        PriorityToDo = Priority.low;
                    }

                    management.GetSchadulesByPrioriytOnSpecialday(PriorityToDo, date);


                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    catch (Exception ex)
    {

        management.Error(ex.Message);
    }
}
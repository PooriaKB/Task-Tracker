using System.Security.Cryptography.X509Certificates;

class TodoList
{
    public static List<string> taskList = new List<string>();// A List For Storing The Tasks
    public static int taskCount = 0;
    // Function For Adding Tasks
    public static void AddTask()
    {
        Console.WriteLine("Enter The Task You Want to Add");
        taskList.Add(Console.ReadLine());
        taskCount++;
        Console.WriteLine("Task Added!");
    }
    // Function For Viewing Tasks
    public static void ViewTask()
    {
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"Task({i + 1}): {taskList[i]}");

        }
    }
    // Function For Complete a Task
    public static void CompleteTask()
    {
        Console.WriteLine("Enter The Number Of The Completed Task");
        var completedTask = Convert.ToInt16(Console.ReadLine());
        if (completedTask > 0 && completedTask <= taskCount)
        {
            taskList[completedTask - 1] = taskList[completedTask - 1] + "(Completed)";
            Console.WriteLine($"Task ({completedTask}) Marked As Completed");
        }
    }

    static void Main(String[] args)
    {
        var running = true;// A Variable For Keep Program Running While It's True.
        try
        {

            while (running)
            {   // Options Of The Program
                Console.WriteLine("Enter The Option You Want:");
                Console.WriteLine("1) Add Task");
                Console.WriteLine("2) View Task");
                Console.WriteLine("3) Complete Task");
                Console.WriteLine("4) Exit");
                var option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ViewTask();
                        break;
                    case 3:
                        CompleteTask();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please Try Again Enter A Valid Option.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Some Error Happened: {e.Message} Run Program Again Please");
        
        }
    }
}
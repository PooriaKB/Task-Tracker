using TaskTracker;

var running = true;

while (running)
{
    Console.WriteLine("Hello & Welcome to Task Tracker App\nChoose an Option By It's Number and Press 'Enter' to Continue. \n");
    Console.WriteLine("1- Add A Task To List.");
    Console.WriteLine("2- Update A Task.");
    Console.WriteLine("3- Delete A Task.");
    Console.WriteLine("4- Mark A Task as Done Or in Progress.");
    Console.WriteLine("5- Show The Tasks List.");
    Console.WriteLine("6- Clear The Tasks List.");
    Console.WriteLine("7- Save File as JSON.");
    Console.WriteLine("8- Exit The App.");
    try
    {

        var option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Actions.AddTask();
                ResetApp();
                break;
            case 2:
                Actions.UpdateTask();
                ResetApp();
                break;
            case 3:
                Actions.DeleteTask();
                ResetApp();
                break;
            case 4:
                Actions.MarkTask();
                ResetApp();
                break;
            case 5:
                Actions.ShowTasks();
                ResetApp();
                break;
            case 6:
                Actions.ClearTasks();
                ResetApp();
                break;
            case 7:
                Actions.Save();
                ResetApp();
                break;
            case 8:
                Console.WriteLine("Exiting The App... Are You Sure? Y/N");
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "y")
                {
                    running = false;
                }
                else
                {
                    ResetApp();
                }
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine("Invalid Option. Try Again.");
        ResetApp();
    }
}

void ResetApp()
{
    Console.WriteLine("Press any Key to Continue.");
    Console.ReadKey();
    Console.Clear();
}

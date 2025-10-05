using System.Text.Json;
namespace TaskTracker
{
    public class Actions
    {
        public static string path = Path.Combine(
          AppContext.BaseDirectory, // bin\Debug\netX
          @"..\..\..\",             // go up 3 levels to project root
          "Tasks",
          "tasks.json"
      );

        public static List<Task> Tasks = new List<Task>();
        public static List<Task> TasksDone = new List<Task>();
        public static List<Task> TasksInProgress = new List<Task>();

        public static void AddTask()
        {
            Console.WriteLine("Enter The Task Description: ");
            var description = Console.ReadLine();
            if(string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Task Description Cannot Be Empty. Try Again.");
                return;
            }
            var task = new Task(description);
            task.updatedAt = DateTime.Now;
            task.ID = Tasks.Max(t => (int?)t.ID) != null ? Tasks.Max(t => t.ID) + 1 : 1; 
            Tasks.Add(task);
            Console.WriteLine($"Task Added Successfully. (ID: {task.ID})");
        }

        public static void UpdateTask()
        {
            if(Tasks.Count != 0 || File.Exists(path))
            {
                Console.WriteLine("Enter The Task ID to Update: ");
                var updatedTaskId = Convert.ToInt32(Console.ReadLine());
                try
                {
                    var updatedTask = Tasks.FirstOrDefault(t => t.ID == updatedTaskId);
                    Console.WriteLine("Enter The New Task Description: ");
                    var description = Console.ReadLine();
                    if (string.IsNullOrEmpty(description))
                    {
                        Console.WriteLine("Task Description Cannot Be Empty. Try Again.");
                        return;
                    }
                    updatedTask.Description = description;
                    updatedTask.updatedAt = DateTime.Now;
                    Console.WriteLine($"Task with ID {updatedTask.ID} Updated Successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Task Not Found.Try Again");
                }

            }
            else
            {
                Console.WriteLine("No Tasks Found");
            }
            

            
        }
        
        public static void DeleteTask()
        {
            if(Tasks.Count != 0 || File.Exists(path)) {

                Console.WriteLine("Enter The Task ID to Delete: ");
                var deletedTaskId = Convert.ToInt32(Console.ReadLine());
                var isExist = Tasks.Any(t => t.ID == deletedTaskId);
                try
                {
                    if (isExist)
                    {
                        var deletedTask = Tasks.FirstOrDefault(t => t.ID == deletedTaskId);
                        Tasks.Remove(deletedTask);
                        Console.WriteLine($"Task with ID {deletedTask.ID}  Deleted Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Task Not Found. Try Again.");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Task Not Found.Try Again");
                }
            }
            else
            {
                Console.WriteLine("Not Task Found");
            }

        }

        public static void MarkTask()
        {
            if (Tasks.Count != 0 || File.Exists(path))
            {
                Console.WriteLine("Enter The Task ID to Mark as Done or In Progress: ");
                var modifiedTaskId = Convert.ToInt32(Console.ReadLine());
                var task = Tasks.FirstOrDefault(t => t.ID == modifiedTaskId);

                if (task == null)
                {
                    Console.WriteLine("Task Not Found. Try Again.");

                }
                else
                {
                    Console.WriteLine("Choose The Status:");
                    Console.WriteLine("1- Done.");
                    Console.WriteLine("2- In Progress.");

                    try
                    {
                        var statusOption = Convert.ToInt32(Console.ReadLine());

                        switch (statusOption)
                        {
                            case 1:
                                task.status = "done";
                                task.updatedAt = DateTime.Now;
                                Console.WriteLine("Task Marked as Done Successfully.");
                                break;
                            case 2:
                                task.status = "in progress";
                                task.updatedAt = DateTime.Now;
                                Console.WriteLine("Task Marked as In Progress Successfully.");
                                break;
                            default:
                                Console.WriteLine("Invalid Option. Try Again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Invalid Option. Try Again.");
                    }

                }

            }
            else
            {
                Console.WriteLine("No Tasks Found");
                    
                }
            }


        public static void ShowTasks()
        {
            if (Tasks.Count != 0 || File.Exists(path))
            {
                Console.WriteLine("Choose What Kind of Tasks to Show:");
                Console.WriteLine("1- All Tasks.");
                Console.WriteLine("2- Todo Tasks.");
                Console.WriteLine("3- In Progress Tasks.");
                Console.WriteLine("4- Done Tasks.");

                try
                {
                    var option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            foreach (var task in Tasks)
                            {
                                if (task.updatedAt == null)
                                {
                                    task.updatedAt = task.CreatedAt;
                                }
                                Console.WriteLine($"ID: {task.ID} | Description: {task.Description} | Status: {task.status} | Created At: {task.CreatedAt} | Updated At: {task.updatedAt}");
                            }
                            break;
                        case 2:
                            var TasksTodo = Tasks.Where(t => t.status == "todo").ToList();
                            foreach (var task in TasksTodo)
                            {
                                if (task.updatedAt == null)
                                {
                                    task.updatedAt = task.CreatedAt;
                                }
                                Console.WriteLine($"ID: {task.ID} | Description: {task.Description} | Status: {task.status} | Created At: {task.CreatedAt} | Updated At: {task.updatedAt}");
                            }
                            break;
                        case 3:
                            TasksInProgress = Tasks.Where(t => t.status == "in progress").ToList();
                            foreach (var task in TasksInProgress)
                            {
                                if (task.updatedAt == null)
                                {
                                    task.updatedAt = task.CreatedAt;
                                }
                                Console.WriteLine($"ID: {task.ID} | Description: {task.Description} | Status: {task.status} | Created At: {task.CreatedAt} | Updated At: {task.updatedAt}");
                            }
                            break;
                        case 4:
                            TasksDone = Tasks.Where(t => t.status == "done").ToList();
                            foreach (var task in TasksDone)
                            {
                                if (task.updatedAt == null)
                                {
                                    task.updatedAt = task.CreatedAt;
                                }
                                Console.WriteLine($"ID: {task.ID} | Description: {task.Description} | Status: {task.status} | Created At: {task.CreatedAt} | Updated At: {task.updatedAt}");
                            }
                            break;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Option. Showing All Tasks.");
                    foreach (var task in Tasks)
                    {
                        if (task.updatedAt == null)
                        {
                            task.updatedAt = task.CreatedAt;
                        }
                        Console.WriteLine($"ID: {task.ID} | Description: {task.Description} | Status: {task.status} | Created At: {task.CreatedAt} | Updated At: {task.updatedAt}");
                    }


                }


            }
            else
            {
                Console.WriteLine("No Tasks Found");
            }

                
        }

        public static void ClearTasks()
        {
            if (Tasks.Count != 0 || File.Exists(path))
            {
                Console.WriteLine("Are You Sure You Want to Clear All Tasks? Y/N");
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "y")
                {
                    Tasks.Clear();
                    Console.WriteLine("All Tasks Cleared Successfully.");
                }
                else
                {
                    Console.WriteLine("Operation Cancelled.");
                }
            }
            else
            {
                Console.WriteLine("No Task Found");
            }
        }

        public static void Save()
        {
            
            if(Tasks.Count != 0)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Tasks, options);
                File.WriteAllText(path, jsonString);
                Console.WriteLine("Tasks Saved Successfully.");

            }
            else
            {
                Console.WriteLine("There is No Task To Save");
            }
           

        }
    }

    
}

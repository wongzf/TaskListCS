using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

public class Program
{
    //Variables
    private static List<Task> TaskList = new List<Task>();

    public static void Main(string[] args)
    {
        bool isRunning = true; //Bool if system is still running, switch to 'false' to shut down

        while (isRunning)
        {
            //Print Instruction lines

            Console.WriteLine("\nWZF Task List");
            Console.WriteLine("==========================================================");
            DisplayAllTasks();
            Console.WriteLine("1. Add Task            2. Change Task Status");
            Console.WriteLine("3. Delete Task         0. Exit Program      ");
            Console.Write("Input number to choose option: ");
            //Read User Input
            var input = Console.ReadLine();

            //Switch Statement based on user input
            switch (input)
            {

                case "1":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Add Task");
                    Console.WriteLine("----------------------------------------------------------");
                    AddTask();
                    break;

                case "2":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Change Task Status");
                    Console.WriteLine("----------------------------------------------------------");
                    ChangeTaskStatus();
                    break;

                case "3":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Delete Task");
                    Console.WriteLine("----------------------------------------------------------");
                    DeleteTask();
                    break;

                case "0":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Exit Program");
                    Console.WriteLine("==========================================================");
                    isRunning = false;
                    break;

                case "100":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Debug Test Command");
                    Console.WriteLine("----------------------------------------------------------");
                    DebugTest();
                    break;

                default:
                    Console.WriteLine("Invalid Input! Please try again");
                    break;
            }
        }
    }



    //Function to Create a task and add it to the TaskList List
    private static void AddTask()
    {
        Console.Write("Input Task Text: ");
        var taskName = Console.ReadLine();

        Console.Write("Enter Due Date (dd-mm-yyyy): ");
        DateTime dueDate;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dueDate))
        {
            Console.Write("Invalid date format! Please enter the date (dd-mm-yyyy): ");
        }

        Console.Write("Is the task completed? (Y/N): ");
        bool isCompleted = false;
        string completionInput = "";

        while (completionInput != "Y" && completionInput != "N")
        {
            completionInput = Console.ReadLine().ToUpper();
            if (completionInput == "Y")
            {
                isCompleted = true;
            }
            else if (completionInput == "N")
            {
                isCompleted = false;
            }
            else
            {
                Console.Write("Invalid input! Please enter 'Y' for Yes or 'N' for No: ");
            }

            Task newTask = new Task(taskName, dueDate, isCompleted);
            TaskList.Add(newTask);
            Console.WriteLine("Task added successfully!");
            ReturnToMainMenu();
        }
    }

    private static void DeleteTask()
    {
        //If tasklist is empty
        if (TaskList.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else //Print out tasklist but add a number to the front for user to pick
        {
            // Table Header, needs further formatting to look nice
            Console.WriteLine("\nNo. || All Tasks || Due Date || Status");
            Console.WriteLine("----------------------------------------------------------"); ;
            //Loop thru TaskList list to cout all task
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                TaskList[i].PrintTask();
            }
            Console.WriteLine("0. Return to Main Menu");
        }
        //Get user input for task number
        Console.Write("Input Task No. to delete: ");
        int taskNo;
        //Check if user input is invalid, NaN or OOB.
        while (!int.TryParse(Console.ReadLine(), out taskNo) || taskNo < 0 || taskNo > TaskList.Count)
        {
            Console.Write("Invalid input! Please enter a valid task number: ");
        }

        if (taskNo == 0)
        {
            Console.WriteLine("Returning to Main Menu...");
            return;
        }
        else
        {
            string confirm = "";
            while (confirm != "Y" && confirm != "N")
            {
                Console.Write("Are you sure you want to delete task No. " + taskNo + "? (Y/N): ");
                confirm = Console.ReadLine().ToUpper();

                if (confirm != "Y" && confirm != "N")
                {
                    Console.WriteLine("Invalid input! Please enter 'Y' for Yes or 'N' for No.");
                }
            }

            if (confirm == "Y")
            {
                TaskList.RemoveAt(taskNo - 1);
                Console.WriteLine("Task deleted successfully!");
            }
            else if (confirm == "N")
            {
                Console.WriteLine("Task deletion cancelled.");
            }

            ReturnToMainMenu();
        }
    }

    //Function to print all task
    private static void DisplayAllTasks()
    {
        // If there are no task, Show "No task Available"
        if (TaskList.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            // Table Header, needs further formatting to look nice
            Console.WriteLine("All Tasks || Due Date || Status");
            Console.WriteLine("----------------------------------------------------------"); ;
            //Loop thru TaskList list to cout all task
            for (int i = 0; i < TaskList.Count; i++)
            {
                TaskList[i].PrintTask();
            }
        }
        Console.WriteLine("==========================================================");
    }

    private static void ChangeTaskStatus()
    {
        //If tasklist is empty
        if (TaskList.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else //Print out tasklist but add a number to the front for user to pick
        {
            // Table Header, needs further formatting to look nice
            Console.WriteLine("\nNo. || All Tasks || Due Date || Status");
            Console.WriteLine("----------------------------------------------------------"); ;
            //Loop thru TaskList list to cout all task
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                TaskList[i].PrintTask();
            }
            Console.WriteLine("0. Return to Main Menu");
        }

        //Get user input for task number
        Console.Write("Input Task No. to switch Completion Status: ");
        int taskNo;
        //Check if user input is invalid, NaN or OOB.
        while (!int.TryParse(Console.ReadLine(), out taskNo) || taskNo < 0 || taskNo > TaskList.Count)
        {
            Console.Write("Invalid input! Please enter a valid task number: ");
        }

        if (taskNo == 0)
        {
            Console.WriteLine("Returning to Main Menu...");
            return;
        }
        else
        {
            // Toggle completion status
            TaskList[taskNo - 1].IsCompleted = !TaskList[taskNo - 1].IsCompleted;

            Console.Write("Task No." + taskNo + " completion status updated to: ");
            if (TaskList[taskNo - 1].IsCompleted == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("COMPLETE\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("INCOMPLETE\n");
                Console.ResetColor();
            }
            //Console.WriteLine("Returning to Main Menu...");
            ReturnToMainMenu();
        }
    }

    private static void ReturnToMainMenu()
    {
        Console.WriteLine("==========================================================\n");
        Console.WriteLine("Press Enter to return to the main menu...");

        // Only allow the Enter key to proceed
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            Console.Clear();
        }
    }
    private static void DebugTest() 
    {
    }
}

public class Task
{
    // Variables
    private string tasktext; // Task Name/Text
    public string TaskText { get; set; } // Auto Getter and Setter

    private DateTime duedate; // When is the task due? 
    public DateTime DueDate { get; set; }

    private bool iscompleted; // Is the task completed?
    public bool IsCompleted { get; set; }

    // Constructor for Task
    public Task(string taskText, DateTime dueDate, bool isCompleted)
    {
        TaskText = taskText;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }

    public void PrintTask() 
    {
        Console.Write(TaskText + " || " + DueDate.ToString("dd-MM-yyyy") + " || ");
        //Set Completed text instead of just True/False
        if (IsCompleted)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("COMPLETE\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("INCOMPLETE\n");
            Console.ResetColor();
        }
    }
}
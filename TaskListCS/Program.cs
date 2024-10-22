/*
 * File: Program.cs
 * Description: Contains a simple Task List Manager program
 *              for the technical interview of Yokogawa.
 * Author: Wong Zi Feng
 * Created: 22-10-2024
 * Version: 1.0
 * 
 */

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
            Console.WriteLine("1. Add Task                 4. Sort by Completion Status");
            Console.WriteLine("2. Change Task Status       5. Sort by Due Date");
            Console.WriteLine("3. Delete Task              0. Exit Program");
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

                case "4":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Sort by Completion Status");
                    Console.WriteLine("----------------------------------------------------------");
                    SortTasksByCompletionStatus();
                    break;

                case "5":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Sort by Due Date");
                    Console.WriteLine("----------------------------------------------------------");
                    SortTasksByDueDate();
                    break;

                case "0":
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Exit Program");
                    Console.WriteLine("==========================================================");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid Input! Please try again");
                    break;
            }
        }
    }



    /*
     * AddTask() - Creates a task from user input and adds it to the tasklist
     */
    private static void AddTask()
    {
        //Console.Write("Input Task Text: ");
        //var taskName = Console.ReadLine();
        
        //Updated so user cannot enter a blank text
        var taskName = "";
        do
        {
            Console.Write("Enter Task Text: ");
            taskName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(taskName))
            {
                Console.WriteLine("Task text cannot be blank. Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(taskName));

        //Change the input format to a more common DD-MM-YYYY instead of YYYY-MM-DD
        Console.Write("Enter Due Date (dd-mm-yyyy): ");
        DateTime dueDate;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dueDate))
        {
            Console.Write("Invalid date format! Please enter the date (dd-mm-yyyy): ");
        }

        //Change setting the status from true/false to Yes/No
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
            //ReturnToMainMenu();
        }
    }

    /*
     * DeleteTask() - Prints all task with numbers and let user select a task to remove from the tasklist
     */
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

            //ReturnToMainMenu();
        }
    }

    /*
     * DisplayAllTask() - Prints all tasks from tasklist
     */
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

    /*
     * ChangeTaskStatus() - Changes the completion status of a task from "Incomplete" to "Complete" and vice versa
     */
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
            //ReturnToMainMenu();
        }
    }

    /*
     * SortTasksByCompletionStatus() - Sorts all tasks in tasklist by completion status. Incomplete first, Completed last.
     */
    private static void SortTasksByCompletionStatus() 
    {
        TaskList.Sort((task1, task2) => task1.IsCompleted.CompareTo(task2.IsCompleted));
        Console.WriteLine("Tasks sorted by Completion Status.");
        Console.WriteLine("Returning to Main Menu...");
    }

    /*
     * SortTasksByDueDate() - Sorts all tasks in tasklist by due date, earliest to latest.
     */
    private static void SortTasksByDueDate() 
    {
        TaskList.Sort((task1, task2) => task1.DueDate.CompareTo(task2.DueDate));
        Console.WriteLine("Tasks sorted by Due Date.");
        Console.WriteLine("Returning to Main Menu...");
    }

    /*
     * ReturnToMainMenu() - Makes the user input "Enter" before loading the Main menu again. DEPRECATED FOR NOW
     */
    private static void ReturnToMainMenu()
    {
        Console.WriteLine("==========================================================\n");
        Console.WriteLine("Press Enter to return to the main menu...");

        // Only allow the Enter key to proceed
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {

        }
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
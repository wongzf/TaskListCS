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
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display All Tasks");
            Console.WriteLine("3. Change Task Status");
            Console.WriteLine("0. Exit Program");
            Console.Write("Input number to choose option: ");
            //Read User Input
            var input = Console.ReadLine();

            //Switch Statement based on user input
            switch (input) 
            {
                case "1" :
                    Console.WriteLine("Add Task Selected!");
                    AddTask();
                    break;

                case "2" :
                    Console.WriteLine("Display Task Selected!");
                    DisplayAllTasks();
                    break;

                case "3" :
                    Console.WriteLine("Change Task Status Selected!");
                    ChangeTaskStatus();
                    break;

                case "0" :
                    Console.WriteLine("Exit Program Selected!");
                    isRunning = false;
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
        Console.WriteLine("Input Task Text: ");
        string taskName = Console.ReadLine();

        Console.WriteLine("Enter Due Date (yyyy-mm-dd): ");
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.WriteLine("Invalid date format! Please enter the date (yyyy-mm-dd): ");
        }
        
        Console.WriteLine("Is the Task completed? (true/false)");
        bool isCompleted;
        while (!bool.TryParse(Console.ReadLine(), out isCompleted))
        {
            Console.WriteLine("Invalid input! Please enter true or false: ");
        }
        
        Task newTask = new Task(taskName, dueDate, isCompleted);
        TaskList.Add(newTask);
        Console.WriteLine("Task added successfully! Returning to Main Menu...");
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
            Console.WriteLine("\nAll Tasks || Due Date || Status");
            
            //Loop thru TaskList list to cout all task
            for (int i = 0; i < TaskList.Count; i++)
            {
                string TaskText = TaskList[i].TaskText;
                DateTime DueDate = TaskList[i].DueDate;
                string IsCompletedText = "Incomplete!";

                //Set Completed text instead of just True/False
                if (TaskList[i].IsCompleted)
                {
                    IsCompletedText = "Completed!";
                }
                else 
                {
                    IsCompletedText = "Incomplete!";
                }

                Console.WriteLine(TaskText + " || " + DueDate + " || " + IsCompletedText);
            }
        }
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

            //Loop thru TaskList list to cout all task
            for (int i = 0; i < TaskList.Count; i++)
            {
                string TaskText = TaskList[i].TaskText;
                DateTime DueDate = TaskList[i].DueDate;
                string IsCompletedText = "Incomplete!";

                //Set Completed text instead of just True/False
                if (TaskList[i].IsCompleted)
                {
                    IsCompletedText = "Completed!";
                }
                else
                {
                    IsCompletedText = "Incomplete!";
                }

                Console.WriteLine(i + 1 + ". " + TaskText + " || " + DueDate + " || " + IsCompletedText);
            }
            Console.WriteLine("0. Return to Main Menu");
        }

        //Get user input for task number
        Console.Write("Input Task No. to switch Completion Status: ");
        int taskNo;
        //Check if user input is invalid, NaN or OOB.
        while (!int.TryParse(Console.ReadLine(), out taskNo) || taskNo < 0 || taskNo > TaskList.Count)
        {
            Console.WriteLine("Invalid input! Please enter a valid task number: ");
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
            string IsCompletedText = "Incomplete!";
            if (TaskList[taskNo - 1].IsCompleted == true) 
            {
                IsCompletedText = "Completed!";
            }
            else
            {
                IsCompletedText = "Incomplete!";
            }
            Console.WriteLine("Task No." + taskNo + " completion status updated to: " + IsCompletedText);
            Console.WriteLine("Returning to Main Menu...");
        }
        
    }
}

public class Task
{
    // Variables
    private string tasktext; // Task Name/Text
    public string TaskText { get; set; } // Auto Getter and Setter

    private DateTime duedate; // When is the task due? 
    public DateTime DueDate { get; set; } // Auto Getter and Setter

    private bool iscompleted; // Is the task completed?
    public bool IsCompleted { get; set; } // Auto Getter and Setter

    // Constructor for Task
    public Task(string taskText, DateTime dueDate, bool isCompleted)
    {
        TaskText = taskText;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }
}
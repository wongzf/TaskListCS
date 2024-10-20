using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

public class Program
{

    private static List<Task> TaskList = new List<Task>();

    public static void Main(string[] args)
    {
        bool isRunning = true; //Bool if system is still running, switch to 'false' to shut down

        while (isRunning) 
        {
            //Print Instruction lines
            Console.WriteLine("\nWZF Task List");
            Console.WriteLine("=========================================");
            Console.WriteLine("Input number to choose option: ");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display All Tasks");
            Console.WriteLine("3. Change Task Status");
            Console.WriteLine("0. Exit Program");

            //Read User Input
            string input = Console.ReadLine();

            //Switch Statement based on user input
            switch (input) 
            {
                case "1" :
                    Console.WriteLine("Add Task Selected");
                    AddTask();
                    break;

                case "2" :
                    Console.WriteLine("Display Task Selected");
                    DisplayAllTasks();
                    break;

                case "3" :
                    Console.WriteLine("Change Task Status Selected");
                    break;

                case "0" :
                    Console.WriteLine("Exit Program Selected");
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
            Console.Write("Invalid date format! Please enter the date (yyyy-mm-dd): ");
        }
        
        Console.WriteLine("Is the Task completed? (true/false)");
        bool isCompleted;
        while (!bool.TryParse(Console.ReadLine(), out isCompleted))
        {
            Console.Write("Invalid input! Please enter true or false: ");
        }
        
        Task newTask = new Task(taskName, dueDate, isCompleted);
        TaskList.Add(newTask);
        Console.WriteLine("Task added successfully! Returning to Main Menu\n");
    }

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
                string IsCompletedText = "Incomplete";

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
}

public class Task
{
    private string tasktext;
    public string TaskText { get; set; } // Task Name/Text

    private DateTime duedate;
    public DateTime DueDate { get; set; } // When is the task due? 

    private bool iscompleted;
    public bool IsCompleted { get; set; } // Is the task completed?

    // Constructor for Task
    public Task(string taskText, DateTime dueDate, bool isCompleted)
    {
        TaskText = taskText;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }
}
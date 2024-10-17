using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning) 
        {
            //Print Instruction lines
            Console.WriteLine("WZF Task List");
            Console.WriteLine("Input number to choose option: ");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display All Tasks");
            Console.WriteLine("3. Change Task Status");
            Console.WriteLine("0. Exit Program");

            //Read User Input
            string input = Console.ReadLine();

            switch (input) 
            {
                case "1" :
                    Console.WriteLine("Add Task Selected");
                    break;

                case "2" :
                    Console.WriteLine("Display Task Selected");
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
}
﻿// references code with different namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace: defines the scope of your code. Thank of it as a "folder"
namespace CSCrashCourse
{
    class Program
    {
        // Method naming convention: Start with upper case letters
        static void Main(string[] args)
        {
            int counter = 3;
            bool isBoring = false;

            // string is an alias for String. It isn't actually a value type
            string title = "C# Crash Course";

            Console.WriteLine("Hello World!");

            Console.WriteLine("Please enter your name: ");

            string name = Console.ReadLine();

            if (!isBoring)
            {

                // interpolated strings: Use $ before declaring a string, and you can include 
                //the string value of variables in your string without manually concatenating
                Console.WriteLine($"Hey {name}, hope you enjoy {title}.\nPress any key to continue.");
                Console.ReadKey();

            }
        }
    }
}
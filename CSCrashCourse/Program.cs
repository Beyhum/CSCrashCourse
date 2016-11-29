// references code with different namespaces
using CSCrashCourse.Models;
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

        // delegates are references to methods
        // when creating a new delegate, we need to define the signature of the methods it will point to
        // in this case, it returns void and doesn't take any parameters
        // we also have to define our delegate's type. In this case, MyDelegateType
        delegate void MyDelegateType();

        delegate int ComputeDelegate(int input);

        // Method naming convention: Start with upper case letters
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();

            InitializeStudents(alarm);

            // calling OnRing will raise the Ring event, which will call its subscribed methods: firstStudent.Study and secondStudent.WasteTime
            alarm.OnRing().Wait();
            Console.ReadKey();

        }

        static int Compute(int x)
        {
            return x * 2;
        }

        static void InitializeStudents(Alarm alarm)
        {
            Student firstStudent = new Freshman("Genn", "Eric", 20);
            Student secondStudent = new Student(lastName: "Ron", firstName: "Dominic");
            Student thirdStudent = new Student("Bob", "Ross")
            {
                Age = 17
            };

            // by using +=, we say that firstStudent.Study is "subscribing" to the Ring event
            // whenever Ring is called, all the subscribed methods will also be called
            alarm.Ring += firstStudent.Study;

            alarm.Ring += secondStudent.WasteTime;


        }

        static void DelegateIntro()
        {
            // here we create an instance of our delegate
            // since HelloWorld() has the same signature (returns void, no params), we can assign it to our delegate
            MyDelegateType delegateInstance = HelloWorld;

            // calling delegateInstance() here will simply call HelloWorld()
            delegateInstance();

            ComputeDelegate computeInstance = Compute;

            int result = computeInstance(5);
            Console.WriteLine("The result of computeInstance is: " + result);

            Console.ReadKey();
        }

        static void HelloWorld()
        {
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

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
            // the Compute method has a signature of: return int, take int as param
            //ComputeDelegate computeInstance = Compute;

            // instead of defining a Compute method, we can use anonymous methods
            // declare anon methods: delegate (params){body}
            // the anonymous method's signature has to match the delegate's signature. In this case return int, take int as param
            ComputeDelegate computeInstance = delegate (int x)
            {
                return x * 2;
            };

            // when we defined ComputeDelegate, we already specified the signature of the methods it can reference
            // the compiler already knows what params a method should take and what its return type should be
            // so why do we need to specify the parameter's type?

            // we can use lambda expressions, which are anonymous functions written with less code
            // lambdas use the syntax: (param list) => { body} or (param list) => (return type)
            ComputeDelegate computeInstance2 = (x) => { return x * 2; }; // or (x) => (x*2);
            // we don't need to specify x's type, because when we defined the ComputeDelegate type,
            // we specified that it takes one parameter of type int. So x must be an int


            // lambdas are just a quick way to define anonymous functions , a way of expressing a method/function
            // they're very convenient because we can pass them as parameters

            var studentList = new List<Student> { new Student("Genn", "Eric", 20), new Student("Bob", "Ross", 23) };

            // the .Where() method is a LINQ method which takes a Func<Student, bool> as param
            // the type Func<T, R> refers to a method which takes a parameter of type T and returns a value of type R
            // since lambda expressions return methods, we can use them as parameters in the Where() method
            var filteredList = studentList.Where((student => (student.Age > 20))).ToList();



            // The line above is equivalent to the following 2 statements:
            /*
            Func<Student, bool> explicitFunc = student => (student.Age > 20);
            var filteredList = studentList.Where(explicitFunc).ToList();

                OR

            Func<Student, bool> explicitFunc = delegate(Student student) { return student.Age > 20; } ;
            var filteredList = studentList.Where(explicitFunc).ToList();
            */

            // we now have a list of students where Age > 20
            foreach (Student student in filteredList)
            {
                Console.WriteLine(student.FullName);
            }

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

            // calling OnRing will raise the Ring event, which will call its subscribed methods: firstStudent.Study and secondStudent.WasteTime
            alarm.OnRing().Wait();


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

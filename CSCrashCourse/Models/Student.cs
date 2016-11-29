using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCrashCourse.Models
{
    public class Student
    {
        #region basicImplementation
        //field:
        //string firstName;


        // Properties are methods which act like fields. So you can do things such as studentInstance.FirstName += "name"
        // Behind the scenes, Properties compile to methods which are called whenever you use string x = instance.FirstName (calls getter method)
        // or instance.FirstName = "name" (calls setter method)
        // property:
        //public string FirstName
        //{
        //    // compiles to get_FirstName()
        //    get
        //    {
        //        return firstName;
        //    }

        //    // compiles to set_FirstName(string value)
        //    set
        //    {
        //        firstName = value;
        //    }
        //}

        #endregion

        // write "prop" + TAB to create an autoproperty
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int Age { get; set; }

        protected virtual double BreakLength { get { return 2; } }
        protected virtual double StudyLength { get { return 1; } }


        // we've set a default value for age. We can ommit it in the constructor
        public Student(string firstName, string lastName, int age = 17)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }




        private string Talk(string message)
        {
            Console.WriteLine($"{FullName}: {message}");
            return message;
        }

        public double WasteTime()
        {
            Talk($"I need to take a {BreakLength} hour break");
            return BreakLength;
        }

        // use the virtual keyword to make a method override-able
        public virtual double Study()
        {
            Talk($"{StudyLength} hours of studying should be enough");
            return StudyLength;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCrashCourse.Models
{
    // use : to inherit or implement
    public class Freshman : Student
    {
        // you can override properties since they are implemented as methods
        protected override double StudyLength
        {
            get
            {
                return 0.75;
            }
        }

        protected override double BreakLength
        {
            get
            {
                return 3;
            }
        }


        public Freshman(string firstName, string lastName, int age = 16) : base(firstName, lastName, age)
        {

        }


        // use the override keyword to override a method. However remember to define that method as virtual in parent
        public override async Task<double> Study()
        {
            return await base.Study() + await WasteTime();

        }
    }
}

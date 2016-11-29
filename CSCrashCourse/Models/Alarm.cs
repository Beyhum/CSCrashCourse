using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCrashCourse.Models
{
    class Alarm
    {

        // this delegate matches the signature of Study() and WasteTime() in Student
        public delegate Task<double> AlarmHandler();

        // events use delegates to call other methods whenever raised
        public event AlarmHandler Ring;

        // it's considered good practice to implement an OnEventRaised method to check if the event has any methods subscribed
        public async Task OnRing()
        {
            if (Ring != null)
            {
                await Ring();
            }
        }
    }
}

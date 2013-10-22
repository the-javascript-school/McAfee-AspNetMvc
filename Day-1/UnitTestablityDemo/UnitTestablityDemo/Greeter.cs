using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestablityDemo
{
    public interface IGreeter
    {
        string Greet(string name);
    }

    public class Greeter : IGreeter
    {
        ITimeService timeService;
        public Greeter(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string Greet(string name)
        {
            if (this.timeService.GetCurrentDateTime().Hour < 12)
            {
                return string.Format("Good Morning {0}", name);
            }
            else
            {
                return string.Format("Good Evening {0}", name);
            }
        }
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }

    public interface ITimeService {
        DateTime GetCurrentDateTime();
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestablityDemo;

namespace GreeterMVCApp.Controllers
{
    public class GreetingController : Controller
    {
        private ITimeService timeService;
        private IGreeter greeter;
        
        public GreetingController(ITimeService timeService, IGreeter greeter)
        {
            this.timeService = timeService;
            this.greeter = greeter;
        }
        public GreetingController()
        {
            this.timeService = new TimeService();
            this.greeter = new Greeter(this.timeService);
        }
        public ViewResult Greet(string userName) {
            var greetMsg = this.greeter.Greet(userName);
            //Debug.WriteLine(greetMsg);
            //this.ViewData["greetMsg"] = greetMsg;
            var data = new ViewDataDictionary();
            data.Add("greetMsg", greetMsg);

            if (this.timeService.GetCurrentDateTime().Hour < 12)
            {
                //return string.Format(morningHTML, userName);
              
                return new ViewResult { ViewName = "Morning", ViewData = data };
            }
            else
            {
                return new ViewResult { ViewName = "Evening", ViewData = data };
            }
            
        }
    }
}
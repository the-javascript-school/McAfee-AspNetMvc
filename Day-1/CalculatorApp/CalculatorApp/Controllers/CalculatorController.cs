using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ViewResult Index(CalculatorInput input)
        {
            var result = 0;
            var errorMessages = new ErrorMessages();
            if (input.Number1 == 0) errorMessages.Add("Number1", "Number1 cannot be 0 or empty");
            if (input.Number2 == 0) errorMessages.Add("Number2", "Number2 cannot be 0 or empty");
            if (errorMessages.HasErrors) {
                this.ViewBag.CalculatorInput = input;
                this.ViewBag.ErrorMessages = errorMessages;
                return View("Input");
            }
            switch (input.Operation)
            {
                case "Add":
                    result = input.Number1 + input.Number2;
                    break;
                case "Subtract":
                    result = input.Number1 - input.Number2;
                    break;
                case "Divde":
                    result = input.Number1 / input.Number2;
                    break;
                case "Multiply":
                    result = input.Number1 * input.Number2;
                    break;
                default:
                    break;
            }
            var dataToView = new CalculatorResult
            {
                Number1 = input.Number1,
                Number2 = input.Number2,
                Operation = input.Operation,
                Result = result
            };
            
            this.ViewBag.CalculatorResult = dataToView;

            return View("Result");
        }

        public ViewResult CalculatorInput()
        {
            this.ViewBag.CalculatorInput = new CalculatorInput();
            this.ViewBag.ErrorMessages = new ErrorMessages();
            return View("Input");
        }

    }

    public class CalculatorInput
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Operation { get; set; }


    }

    public class CalculatorResult {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Operation { get; set; }
        public int Result { get; set; }
    }

    public class ErrorMessages : IEnumerable
    {
        Dictionary<string, string> _messages = new Dictionary<string, string>();
        public void Add(string attributeName, string message)
        {
            _messages[attributeName] = message;
        }
        public bool HasErrors
        {
            get { return _messages.Count > 0; }
        }
        public string this[string key]
        {
            get { return _messages[key]; }
        }

        public bool ContainsKey(string key) {
            return _messages.ContainsKey(key);
        }


        public IEnumerator GetEnumerator()
        {
            return _messages.GetEnumerator();
        }
    }
}

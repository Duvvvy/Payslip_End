using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Payslip_End {
    public class ConsoleInterface {
        /*
         * The intention of this class is take input and output from the user, through the console.
         */
        
        public string ListDecisionGetter(List<string> arrayOfCorrectAnswers, string question) {
            while (true) {
                Console.Out.WriteLine(question);
                var userInput = GetInputFromUser();
                if (arrayOfCorrectAnswers.Any(input => userInput == input)) {
                    return userInput;
                }
            }
        }

        public string RegexDecisionGetter(Regex regex, string question) {
            while (true) {
                Console.Out.Write("\n" + question);
                var userInput = GetInputFromUser();
                if (regex.IsMatch(userInput)) {
                    return userInput;
                }
            }
        }

        public DateTime DateTimeDecisionGetter(string format, string question) {
            var startDate = DateTime.MinValue;
            var isValid = false;
            while (isValid == false) {
                Console.Out.WriteLine(question);
                isValid = DateTime.TryParseExact(
                    GetInputFromUser(),
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out startDate);
            }
            return startDate;
        }

        protected virtual string GetInputFromUser() {
            return Console.ReadLine();
        }
        
    }
}
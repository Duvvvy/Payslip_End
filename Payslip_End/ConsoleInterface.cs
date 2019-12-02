using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Payslip_End {
    public class ConsoleInterface {
        /*
         * The intention of this class is take input and output from the user, through the console.
         */

        public void WelcomeUser() {
            Console.Out.WriteLine("");
        }


        public string UserDecisionGetter(List<string> arrayOfCorrectAnswers, string question) {
            var validInput = false;
            var userInput = "";
            while (!validInput) {
                Console.Out.WriteLine(question);
                userInput = GetInputFromUser();
                foreach (var input in arrayOfCorrectAnswers.Where(input => userInput == input)) validInput = true;
            }
            return userInput;
        }

        public string TestingDecisionGetter(string question) {
            Regex numberFinder = new Regex(@"\d+");
        
        
            return null;
        }

        protected virtual string GetInputFromUser() {
            return Console.ReadLine();
        }
        
    }
}
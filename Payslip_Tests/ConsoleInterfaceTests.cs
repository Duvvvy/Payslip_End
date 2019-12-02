using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Payslip_End;
using Xunit;

namespace Payslip_Tests {
    public class ConsoleInterfaceTests {
        private class ConsoleInterfaceUserInputAsList : ConsoleInterface {
            public ConsoleInterfaceUserInputAsList(Stack<string> userInput) {
                UserInput = userInput;
            }

            public Stack<string> UserInput { get; }

            protected override string GetInputFromUser() {
                return UserInput.Pop();
            }
        }

        [Fact]
        public void CheckUserDecisionGetter() {
            var testInput = new Stack<string>();
            testInput.Push("test");

            var fake = new ConsoleInterfaceUserInputAsList(testInput);
            var result = fake.ListDecisionGetter(new List<string> {"test", "passed"}, "Please enter 'test'");
            Assert.Equal("test", result);
        }

        [Fact]
        public void CheckRegexDecisionGetter() {
            var testStack = new Stack<string>();
            testStack.Push("19000");
            
            var consoleInjector = new ConsoleInterfaceUserInputAsList(testStack);
            
            Regex rgx = new Regex(@"\d");
            
            var testOutput = consoleInjector.RegexDecisionGetter(rgx, "Please enter a currency value");
            Console.Out.WriteLine(testOutput);
            Assert.Equal("19000",testOutput);
        }
        
    }
}
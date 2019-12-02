using System.Collections.Generic;
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
            var result = fake.UserDecisionGetter(new List<string> {"test", "passed"}, "Please enter 'test'");
            Assert.Equal("test", result);
        }
        
    }
}
using System;
using System.IO;
using Payslip_End;
using Xunit;

namespace Payslip_Tests {
    public class PersonWriterTests {
        [Fact]
        public void ParseTest() {
            var fullPath = Path.GetFullPath("/Users/ryan.bircham/RiderProjects/Payslip_End/Payslip_Tests/test.csv");
            ConsoleInterface consoleInterface = new ConsoleInterface();
            PersonWriter personWriter = new PersonWriter(consoleInterface);
            var output = personWriter.ReadInEnumerablePeopleFromCsv(fullPath);
            foreach (var o in output) {
                Console.Out.WriteLine(o.FirstName);
            }
        }
    }
}
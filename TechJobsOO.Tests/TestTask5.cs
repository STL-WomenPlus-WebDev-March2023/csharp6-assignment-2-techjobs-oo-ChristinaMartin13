using System.Text.RegularExpressions;
using TechJobs.Tests;

namespace TechJobsOO.Tests
{
    [TestClass]
    public class TestTask5
    {
        //Task 5 Tests used to verify that students are testing their custom ToString method.
        //Uses jobs from the Job class.
        //Tests are numbered.


        //Unit Test 1:  TestToStringStartsAndEndsWithNewLine  -----------------------


        [TestMethod]  //1
        public void TestToStringStartsAndEndsWithNewLineExists()
        {
            //test to verify that TestToStringStartsAndEndsWithNewLine exisits

            //setup
            Type testType = typeof(JobTests);
            MemberInfo[] memberInfos = testType.GetMembers();
            string nameCheck = "TestToStringStartsAndEndsWithNewLine";
            string existsCheck = "";

            foreach (var mCheck in memberInfos)
            {
                if (mCheck.Name == nameCheck)
                {
                    existsCheck += "true";
                    break;
                }
            }

            //verify test was created
            Assert.AreEqual("true", existsCheck, "'TestToStringStartsAndEndsWithNewLine' not created");
        }

        [TestMethod]  //2
        public void Test_TestToString_Starts_And_Ends_With_NewLine()
        {
            //comparing output to a text file.

            //setup
            string fromFile = File.ReadAllText("StartsAndEndsWithNewLine.txt").ToString();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var job = new RunTechJobs();
            job.RunProgram();
            string rawOutput = stringWriter.ToString();

            string comparisonText = StandardizeLineBreaks(fromFile);
            string correctedOutput = StandardizeLineBreaks(rawOutput);
            string expected = SyncOutputTestIdNumbers(comparisonText, correctedOutput);

            //verify
            Assert.AreEqual(expected, correctedOutput, "New Line issue");
        }

        //Unit Test 2: TestToStringContainsCorrectLabelsAndData -----------------------


        [TestMethod]  //3
        public void TestToStringContainsCorrectLabelsAndData_Exists()
        {
            //test to verify that TestToStringContainsCorrectLabelsAndData exisits

            //setup
            Type testType = typeof(JobTests);
            MemberInfo[] memberInfos = testType.GetMembers();
            string nameCheck = "TestToStringContainsCorrectLabelsAndData";
            string existsCheck = "";

            foreach (var mCheck in memberInfos)
            {
                if (mCheck.Name == nameCheck)
                {
                    existsCheck += "true";
                    break;
                }
            }

            //verify test was created
            Assert.AreEqual("true", existsCheck, "'TestToStringContainsCorrectLabelsAndData' not created");
        }


        [TestMethod]  //4
        public void Test_TestToStringContainsCorrectLabelsAndData()
        {
            //comparing output to a text file.
            //id numbers may get a little wonky

            //setup
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var job = new RunTechJobs();
            job.RunProgram();
            var output = stringWriter.ToString();

            //verify
            Assert.IsTrue(output.Contains($"Name: Product tester") && output.Contains("Employer: ACME") && output.Contains("Location: Desert") && output.Contains("Position Type: Quality control") && output.Contains("Core Competency: Persistence"));

        }


        //Unit Test 3: TestToStringHandlesEmptyField --------------------

        [TestMethod] //5
        public void TestToStringHandlesEmptyField_Exists()
        {
            //test to verify that TestToStringHandlesEmptyField exisits
            //setup

            Type testType = typeof(JobTests);
            MemberInfo[] memberInfos = testType.GetMembers();
            string nameCheck = "TestToStringHandlesEmptyField";
            string existsCheck = "";

            foreach (var mCheck in memberInfos)
            {
                if (mCheck.Name == nameCheck)
                {
                    existsCheck += "true";
                    break;
                }
            }

            //verify test was created
            Assert.AreEqual("true", existsCheck, "'TestToStringHandlesEmptyField' not created");
        }


        [TestMethod] //6
        public void Test_TestToStringHandlesEmptyField()
        {
            //comparing output to a text file.

            string fromFile = File.ReadAllText("EmptyFieldTest.txt").ToString();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var job = new RunTechJobs();
            job.RunProgram();
            var rawOutput = stringWriter.ToString();

            string comparisonText = StandardizeLineBreaks(fromFile);
            string correctedOutput = StandardizeLineBreaks(rawOutput);
            string expected = SyncOutputTestIdNumbers(comparisonText, correctedOutput);

            //verify
            Assert.AreEqual(expected, correctedOutput, "Empty string handling error");
        }

        private string SyncOutputTestIdNumbers(string target, string source)
        {
            int startId = GetConsoleOutputStartId(source) - 1;
            const string pattern = @"ID: \d+";
            return Regex.Replace(target, pattern, delegate (Match m)
            {
                startId++;
                return $"ID: {startId}";
            });
        }

        private int GetConsoleOutputStartId(string consoleOutput)
        {
            const string pattern = @"(?:ID: )(\d+)";
            Match match = Regex.Match(consoleOutput, pattern);
            return match.Success ? int.Parse(match.Groups[1].Value) : 1;
        }

        private string StandardizeLineBreaks(string text)
        {
            //Linux and modern Macs use \n, Windows uses \r\n, old Macs use \r
            const string pattern = @"\r?\n|\r";
            return Regex.Replace(text, pattern, Environment.NewLine);
        }


    }

}

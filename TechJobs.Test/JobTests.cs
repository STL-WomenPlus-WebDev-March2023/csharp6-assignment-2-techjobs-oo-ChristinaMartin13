
using TechJobsOOAutoGraded6;

namespace TechJobs.Tests
{
	[TestClass]
	public class JobTests
	{
        //Testing Objects
        Job job1 = new Job();

        Job job2 = new Job();

        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job5 = new Job("Product tester", new Employer(""), new Location("Desert"), new PositionType(""), new CoreCompetency("Persistence"));

        //initalize your testing objects here
        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreNotEqual(job1.Id, job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester",job3.Name);
            Assert.AreEqual("ACME",job3.EmployerName.Value);
            Assert.AreEqual("Desert",job3.EmployerLocation.Value);
            Assert.AreEqual("Quality control",job3.JobType.Value);
            Assert.AreEqual("Persistence",job3.JobCoreCompetency.Value);

        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job2.Equals(job4));
        }

        [TestMethod]

        public void TestToStringStartsAndEndsWithNewLine()
        {
            Assert.IsTrue(job3.ToString().StartsWith("\n"));
            Assert.IsTrue(job3.ToString().EndsWith("\n"));
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string expectedString = $"\nID: {job3.Id}\nName: {job3.Name}\nEmployer: {job3.EmployerName.Value}\nLocation: {job3.EmployerLocation.Value}\nPosition Type: {job3.JobType.Value}\nCore Competency: {job3.JobCoreCompetency.Value}\n";
            string actualString = job3.ToString();
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]

        public void TestToStringHandlesEmptyField()
        {
            string expectedString = $"\nID: {job5.Id}\nName: {job5.Name}\nEmployer: {job5.EmployerName.Value}\nLocation: {job5.EmployerLocation.Value}\nPosition Type: {job5.JobType.Value}\nCore Competency: {job5.JobCoreCompetency.Value}\n";
            string actualString = job5.ToString();
            Assert.AreEqual(expectedString, actualString);
        }



    }
}


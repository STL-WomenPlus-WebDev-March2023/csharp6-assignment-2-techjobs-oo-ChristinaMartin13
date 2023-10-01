using System;
using System.ComponentModel.Design;
using TechJobsOOAutoGraded6;

namespace TechJobsOOAutoGraded6
{
	public class Job
	{
        

            public int Id { get; }
            private static int nextId = 1;
            public string Name { get; set; }
            public Employer EmployerName { get; set; }
            public Location EmployerLocation { get; set; }
            public PositionType JobType { get; set; }
            public CoreCompetency JobCoreCompetency { get; set; }

            // TODO: Task 3: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Task 3: Generate Equals() and GetHashCode() methods.  

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


        // TODO: Task 5: Generate custom ToString() method.
        //Until you create this method, you will not be able to print a job to the console.

        public override string ToString()
        {
            string employerValue = String.IsNullOrEmpty(EmployerName.Value) ? "Data not available" : EmployerName.Value;
            string locationValue = String.IsNullOrEmpty(EmployerLocation.Value) ? "Data not available" : EmployerLocation.Value;
            string jobTypeValue = String.IsNullOrEmpty(JobType.Value) ? "Data not available" : JobType.Value;
            string coreCompetencyValue = String.IsNullOrEmpty(JobCoreCompetency.Value) ? "Data not available" : JobCoreCompetency.Value;

            return $"\nID: {Id}\nName: {Name}\nEmployer: {EmployerName.Value}\nLocation: {EmployerLocation.Value}\nPosition Type: {JobType.Value}\nCore Competency: {JobCoreCompetency.Value}\n";
        }


    }
}


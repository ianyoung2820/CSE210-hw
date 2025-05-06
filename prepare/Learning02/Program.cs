using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Job class
        var job1 = new Job();
        job1._company   = "Microsoft";
        job1._jobTitle  = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear   = 2022;

        var job2 = new Job();
        job2._company   = "Apple";
        job2._jobTitle  = "Manager";
        job2._startYear = 2022;
        job2._endYear   = 2023;

        // Test Resume class
        var myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display everything
        myResume.Display();
    }
}
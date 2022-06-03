using System;
using System.Collections.Generic;
using System.Text;

namespace PROG___Task_2
{
    //Declared abstract class
    abstract class values
    {
        public abstract double Module();
        public abstract double Working();
        public abstract double Semester();
        public abstract double Login();
    }

    //Declared Class Module
    class Module
    {
        public string ID
        { get; set; }

        public string Code
        { get; set; }

        public string Name
        { get; set; }

        public double Credits
        { get; set; }

        public double HoursWeekly
        { get; set; }
    }

    //Declared Class Working
    class Working
    {
        public double HoursWorked
        { get; set; }

        public string WorkingModuleCode
        { get; set; }

        public string DateWorking
        { get; set; }

        public double StudyHoursWeekly
        { get; set; }
    }

    //Declared Class Module
    class Semester
    {
        public double NumWeeks
        { get; set; }

        public string DateSemester
        { get; set; }
    }

    //Declared Class Login
    class Login
    {
        public string Username
        { get; set; }

        public string Password
        { get; set; }
    }
}

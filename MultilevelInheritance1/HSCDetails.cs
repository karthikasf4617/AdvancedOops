using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritance1
{
    public class HSCDetails:StudentInfo
    {
        public int HSCMarksheetNo{get; set;}
        public double Physics{get; set;}
        public double Chemistry{get; set;}
        public double Maths{get; set;}

        public HSCDetails(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,int standard,string branch,int academicYear,int hscMarksheetno,double physics,double chemistry,double maths):base( name,fatherName,phoneNumber, mail, dob, gender,standard,branch,academicYear)
        {
            HSCMarksheetNo=hscMarksheetno;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter Physics Marks");
            double Physics=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Chemistry Marks");
            double Chemistry=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maths Marks");
            double Maths=double.Parse(Console.ReadLine());
        }
        public void Calculate()
        {
            double Total=Physics+Chemistry+Maths;
            double Average=Total/3;
            Console.WriteLine($"Physics : {Physics} \nChemistry : {Chemistry}\nMaths : {Maths}\nTotal : {Total}\nAverage : {Average}");
        }
    }
}
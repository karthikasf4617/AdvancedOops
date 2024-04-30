using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritance1
{
    public class StudentInfo:PersonalInfo
    {
        private int s_registerNumber=1000;
         public string RegisterNumber{get;}
        public int Standard{get;set;}
        public string Branch{get;set;}
        public int AcademicYear{get;set;}

        //constructor
        public StudentInfo(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,int standard,string branch,int academicYear):base(name,fatherName,phoneNumber,mail,dob,gender)
        {
            s_registerNumber++;
            RegisterNumber="RN"+s_registerNumber;
            Standard=standard;
            Branch=branch;
            AcademicYear=academicYear;
        }
        public void GetStudentInfo()
        {
            Console.WriteLine("Enter Your Name");
            string Name=Console.ReadLine();
             Console.WriteLine("Enter Your FatherName");
            string FatherNameName=Console.ReadLine();
             Console.WriteLine("Enter Your Number");
            long PhoneNumber=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your MailId");
            string Mail=Console.ReadLine();
             Console.WriteLine("Enter Your Gender");
            string Gender=Console.ReadLine();
            Console.WriteLine("Enter Your standard");
            int Standard=int.Parse(Console.ReadLine());
             Console.WriteLine("Enter Your Branch");
            string Branch=Console.ReadLine();
            Console.WriteLine("Enter Your Academic");
            int AcademicYear=int.Parse(Console.ReadLine());
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Name : {Name} \n FatherName : {FatherName} \n Gender : {Gender} \nPhoneNumber :  {PhoneNumber} \nRegisterNumber : {RegisterNumber} \nStandard : {Standard} \nBrancg : {Branch} \nAcademic : {AcademicYear}");
        }
        
    }
}
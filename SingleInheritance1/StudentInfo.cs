using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritance1
{
    public class StudentInfo:PersonalInfo
    {
        public int RegisterNumber{get;set;}
        public int Standard{get;set;}
        public string Branch{get;set;}
        public int AcademicYear{get;set;}

        //constructor
        public StudentInfo(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,int registerNumber,int standard,string branch,int academicYear):base(name,fatherName,phoneNumber,mail,dob,gender)
        {
            RegisterNumber=registerNumber;
            Standard=standard;
            Branch=branch;
            AcademicYear=academicYear;
        }
        
    }
}
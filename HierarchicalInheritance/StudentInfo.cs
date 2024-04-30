using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class StudentInfo:PersonalInfo
    {
        private int s_studentId=2000;
        public string StudentId{get;set;}
        public string Degree{get;set;}
        public string Department{get;set;}
        public string Semester{get;set;}
        public StudentInfo(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,string degree,string department,string semester):base(name,fatherName,phoneNumber,mail,dob,gender)
        {
            s_studentId++;
            StudentId="SID"+s_studentId;
            Degree=degree;
            Department=department;
            Semester=semester;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Name : {Name}\nFatherName : {FatherName}\nPhoneNumber : {PhoneNumber}");
            Console.WriteLine($"Mail : {Mail}\nDOB : {DOB} \nGender : {Gender}\nStudentId :{StudentId}");
            Console.WriteLine($"Degree : {Degree} \nDepartment : {Department}\nSemester : {Semester}");
            
        }
    }
}
using System;
using Microsoft.Win32;
namespace MultilevelInheritance1
{
    class Program 
    {
        public static void Main(string[] args)
        {
            PersonalInfo person=new PersonalInfo("Karthika","Ravi",653542432,"RK@gmail.com",new DateTime(09/06/2002),"Female");
            StudentInfo student=new StudentInfo(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,8,"BIO",2023);
            student.GetStudentInfo();
            student.ShowInfo();
            HSCDetails detail=new HSCDetails(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,student.Standard,student.Branch,student.AcademicYear,101,70,85,90);
            detail.GetMarks();
            detail.Calculate();
        }
    }
}

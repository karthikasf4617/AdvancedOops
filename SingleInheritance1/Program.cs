using System;
using Microsoft.Win32;
namespace SingleInheritance1 
{
    class Program 
    {
        public static void Main(string[] args)
        {
            PersonalInfo person=new PersonalInfo("Karthika","Ravi",873573347,"Rk@gmail.com",new DateTime(09/06/2002),"female");
            StudentInfo student=new StudentInfo(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,1234,8,"Biology",2023);
            Console.WriteLine($"Name : {person.Name} \nFatherName : {person.FatherName} \nPhoneNumber : {person.PhoneNumber}\nMail : {person.Mail} \nDOB : {person.DOB}  \nGender : {person.Gender} \nRegisterNo : {student.RegisterNumber}\nStandard : {student.Standard} \nBranch : {student.Branch} \nAcademicYear : {student.AcademicYear}" );
        }
    }
}
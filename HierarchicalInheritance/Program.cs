using System;
namespace HierarchicalInheritance 
{
    class Program 
    {
        public static void Main(string[] args)
        {
            PersonalInfo person=new PersonalInfo("karthika","Ravi",73464276,"rk@gmail.com",new DateTime(09/06/2002),"Female");
            Teacher teacher=new Teacher(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,"IT","Chemistry","M.TECH",10,new DateTime(13/4/2002));
            teacher.ShowDetails();
            StudentInfo student=new StudentInfo(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,"B.TECH","IT","FOUR");
            student.ShowDetails();
            PrincipalInfo principal=new PrincipalInfo(person.Name,person.FatherName,person.PhoneNumber,person.Mail,person.DOB,person.Gender,"P.Hd",23,new DateTime(10/05/2023));
            principal.ShowDetails();
        }
    }
}

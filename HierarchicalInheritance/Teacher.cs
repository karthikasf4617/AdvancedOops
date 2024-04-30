using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class Teacher:PersonalInfo
    {
        private int s_teacherId=1000;
        public string TeacherId{get;set;}
        public string Department{get;set;}
        public string SubjectTeaching{get;set;}
        public string Qualification{get;set;}
        public int YearOfExperience{get;set;}
        public DateTime DateOfJoining{get;set;}

        public Teacher(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,string department,string subjectTeaching,string qualification,int yearOfExperience,DateTime dateOfJoining):base(name,fatherName,phoneNumber,mail,dob,gender)
        {
            s_teacherId++;
            TeacherId="TID"+s_teacherId;
            Department=department;
            SubjectTeaching=subjectTeaching;
            Qualification=qualification;
            YearOfExperience=yearOfExperience;
            DateOfJoining=dateOfJoining;

        }
        public void ShowDetails()
        {
            Console.WriteLine($"Name : {Name}\nFatherName : {FatherName}\nPhoneNumber : {PhoneNumber}");
            Console.WriteLine($"Mail : {Mail}\nDOB : {DOB} \nGender : {Gender}\nTeacherId :{TeacherId}");
            Console.WriteLine($"Department : {Department}\nSubjectTeaching : {SubjectTeaching} \nQualification : {Qualification}\nYearOfExperience :{YearOfExperience}\nDateOfJoining : {DateOfJoining}");
            
        }
        
    }
}
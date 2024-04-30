using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class PrincipalInfo:PersonalInfo
    {
        private int s_principalId=3000;
        public string PrincipalId{get;}
         public string Qualification{get;set;}
        public int YearOfExperience{get;set;}
        public DateTime DateOfJoining{get;set;}
        public PrincipalInfo(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender,string qualification,int yearOfExperience,DateTime dateOfJoining):base(name,fatherName,phoneNumber,mail,dob,gender)
        {
            s_principalId++;
           PrincipalId="PID"+s_principalId;
           Qualification=qualification;
           YearOfExperience=yearOfExperience;
           DateOfJoining=dateOfJoining; 

        }
         public void ShowDetails()
        {
            Console.WriteLine($"Name : {Name}\nFatherName : {FatherName}\nPhoneNumber : {PhoneNumber}");
            Console.WriteLine($"Mail : {Mail}\nDOB : {DOB} \nGender : {Gender}\nPrincipalId :{PrincipalId}");
            Console.WriteLine($"Qualification : {Qualification}\nYearOfExperience :{YearOfExperience}\nDateOfJoining : {DateOfJoining}");
            
        }
        
    }
}
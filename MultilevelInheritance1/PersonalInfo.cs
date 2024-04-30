using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritance1
{
    public class PersonalInfo
    {
        public string Name{get;set;}
        public string FatherName{get; set;}
        public long PhoneNumber{get; set;}
        public string Mail{get;set;}
        public DateTime DOB{get;set;}
        public string Gender{get;set;}

        //constructor
        public PersonalInfo(string name,string fatherName,long phoneNumber,string mail,DateTime dob,string gender)
        {
            Name=name;
            FatherName=fatherName;
            PhoneNumber=phoneNumber;
            Mail=mail;
            DOB=dob;
            Gender=gender;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {
        public string Name{get;set;}
        public int Age{get;set;}
        public string City{get;set;}
        public long PhoneNumber{get;set;}
        public PersonalDetails(string name,int age,string city,long phoneNumber)
        {
            Name=name;
            Age=age;
            City=city;
            PhoneNumber=phoneNumber;    
        }
    }
}
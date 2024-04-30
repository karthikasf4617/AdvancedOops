using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum Gender{select,Male,Female}
    public class PersonalDetail
    {
        //properties
        public string Name{get; set;}
        public string FatherName{get; set;}
        public Gender Gender{get; set;}
        public long Mobile {get;set;}
        public string MailID{get; set;}
        

         //constructor
         public PersonalDetail(string name,string fatherName,Gender gender,long mobile,string mailId)
         {
            
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            MailID=mailId;

         }
    }
}
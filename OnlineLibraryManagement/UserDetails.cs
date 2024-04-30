using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum Gender{select,Male,Female,Transgender}
    public enum Department{ECE,EEE,CSE}
    public class UserDetails
    {
        private static int s_userId=3000;
        public string UserId{get;}
        public string UserName{get;set;}
        public Gender Gender{get;set;}
        public Department Department{get;set;}
        public long MobileNumber{get;set;}
        public string MailId{get;set;}
        public long WalletBalance{get;set;}

        public UserDetails(string userName,Gender gender,Department department,long mobileNumber,string mailId,long walletBalance)
        {
            s_userId++;
            UserId="SF"+s_userId;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailId=mailId;
            WalletBalance=walletBalance;


        }

       public void  Recharge(long recharge)
        {
            WalletBalance+=recharge;
            Console.WriteLine("Balance="+WalletBalance);
           
        }

        public  void  DeductBalance(long deductedbalance)
        {
            WalletBalance=WalletBalance-deductedbalance;
            Console.WriteLine(WalletBalance);
        }


    }
}
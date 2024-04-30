using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        //field
        private double _walletBalance;
        private static int s_customerId=1000;
        //property
        public string CustomerId{get;set;}
        public double WalletBalance{get;set;}
        //Constructor
        public CustomerDetails(string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailId,string location,double _walletBalance):base(name,fatherName, gender,mobile,dob,mailId,location)
        {
            s_customerId++;
            CustomerId="CID"+s_customerId;
            WalletBalance=_walletBalance;
        }
         public CustomerDetails(string customer)
        {
            string[] values=customer.Split(",");
            Name=values[0];
            FatherName=values[1];
            Gender=Enum.Parse<Gender>(values[2],true);
            Mobile=values[3];
            DOB=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            MailID=values[5];
            Location=values[6];
            s_customerId++;
            CustomerId="CID"+s_customerId;
            WalletBalance=_walletBalance;
        }
        //method
        public double WallteRecharge(double recharge)
        {
            _walletBalance+=recharge;
            return _walletBalance;
        }
        public double DeductBalance(double deductamount)
        {
            _walletBalance-=deductamount;
            return _walletBalance;
        }

        
    }
}
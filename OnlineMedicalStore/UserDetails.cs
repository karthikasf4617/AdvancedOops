using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails:PersonalDetails,IWalllet
    {
        private double _walletBalance;
        private static int _userId=1000;
        public double WalletBalance{get{return _walletBalance;}set{value=_walletBalance;}}
        public string UserId{get;set;}
        public UserDetails(string name,int age,string city,long phoneNumber,double _walletBalance):base(name,age,city,phoneNumber)
        {
            _userId++;
            UserId="UID"+_userId;
        }
        public double WalletRecharge(double recharge)
        {
            _walletBalance+=recharge;
            return _walletBalance;
        }
        public double DeductBalance(double deduct)
        {
            _walletBalance-=deduct;
            return _walletBalance;
        }
    }
}
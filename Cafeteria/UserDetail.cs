using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class UserDetail:PersonalDetail,IBalance 
    {
        private int _walletBalance;
        public int WalletBalance{get{return _walletBalance;}set{_walletBalance=value;}} 
        private static int s_userId=1000;
        public string UserId{get;}
        public string WorkStationNumber{get;set;}
        //constuctor
        public UserDetail(string name,string fatherName,Gender gender,long mobile,string mailId,string workstationNo,int walletBalance):base(name,fatherName,gender,mobile,mailId)
        {
            s_userId++;
            UserId="SF"+s_userId;
            WorkStationNumber=WorkStationNumber;
            WalletBalance=_walletBalance;
        }
        //Method
        public int WalletRecharge(int recharge)
        {
            _walletBalance=_walletBalance+recharge;
            return _walletBalance;
        }
        public int DeductAmount(int deduct)
        {
            _walletBalance=_walletBalance-deduct;
            return _walletBalance;
        }

        public int WalletRecharge()
        {
            throw new NotImplementedException();
        }

        public int DeductAmount()
        {
            throw new NotImplementedException();
        }
    }

}
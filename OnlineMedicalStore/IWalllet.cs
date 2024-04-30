using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface IWalllet
    {
        //property
        public double WalletBalance{get;set;}
        double WalletRecharge(double recharge);
        double DeductBalance(double deduct);
    }
}
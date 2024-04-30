using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        //property
        public double WalletBalance{get;set;}
        //method
        double WallteRecharge(double recharge);
        double DeductBalance(double deductamount);
    }
}
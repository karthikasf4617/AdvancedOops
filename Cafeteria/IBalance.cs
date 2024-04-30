using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public interface IBalance
    {
        public int WalletBalance{get;set;}
        int WalletRecharge();
        int DeductAmount();
    }
}
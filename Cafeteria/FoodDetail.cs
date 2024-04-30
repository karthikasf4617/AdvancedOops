using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class FoodDetails
    {
        private static int s_foodId=100;
        public string FoodId{get;}
        public string FoodName{get;set;}
        public int FoodPrice{get;set;}
        public int AvalibleQuantity{get;set;}
        public FoodDetails(string foodName,int foodPrice,int avalibleQuantity)
        {
            s_foodId++;
            FoodId="FID"+s_foodId;
            FoodName=foodName;
            FoodPrice=foodPrice;
            AvalibleQuantity=avalibleQuantity;
        }
    }
}
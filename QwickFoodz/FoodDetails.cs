using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        //field
        private static int s_foodId=2000;
        //property
        public string FoodId{get;set;}
        public string FoodName{get;set;}
        public double PricePerQuantity{get;set;}
        public int QuantityAvalible{get;set;}
        //constructor
        public FoodDetails(string foodName,double pricePerQuantity,int quantityAvalible)
        {
            s_foodId++;
            FoodId="FID"+s_foodId;
            FoodName=foodName;
            PricePerQuantity=pricePerQuantity;
            QuantityAvalible=quantityAvalible;
        }
    }
}
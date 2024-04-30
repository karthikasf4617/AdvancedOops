using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        //field
        private static int s_itemId=100;
        //property
        public string ItemId{get;set;}
        public string OrderId{get;set;}
        public string FoodId{get;set;}
        public int PurchaseCount{get;set;}
        public double PriceOfOrder{get;set;}
        //constructor
        public ItemDetails(string orderId,string foodId,int purchaseCount,double priceOfOrder)
        {
            s_itemId++;
            ItemId="ITID"+s_itemId;
            OrderId=orderId;
            FoodId=foodId;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }
    }
}
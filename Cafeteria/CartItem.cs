using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class CartItem
    {
        private static int s_itemId=100;
        public string ItemId{get;}
        public string OrderId{get;set;}
        public string FoodId{get;set;}
        public int OrderPrice{get;set;}
        public int OrderQuantity{get;set;}
        public CartItem(string orderId,string foodId,int orderPrice,int orderQuantity)
        {
            s_itemId++;
            ItemId="ITID"+s_itemId;
            OrderId=orderId;
            FoodId=foodId;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;


        }
    }
}
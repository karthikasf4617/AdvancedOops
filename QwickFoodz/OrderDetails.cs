using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        //field
        private static int s_orderId=3000;
        //property
        public string OrderId{get;set;}
        public string CustomerId{get;set;}
        public double TotalPrice{get;set;}
        public DateTime DateOfOrder{get;set;}
        public OrderStatus OrderStatus{get;set;}
        //constructor
        public OrderDetails(string customerId,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
        {
            s_orderId++;
            OrderId="OID"+s_orderId;
            CustomerId=customerId;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
        }


    }
}
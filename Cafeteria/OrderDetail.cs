using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled}
    public class OrderDetail
    {
        private static int s_orderId=1000;
        public string OrderId{get;set;}
        public string UserId{get;set;}
        public DateTime OrderDate{get;set;}
        public int TotalPrice{get;set;}
        public OrderStatus OrderStatus{get;set;}

        public OrderDetail(string userId,DateTime orderDate,int totalPrice,OrderStatus orderStatus)
        {
            s_orderId++;
            OrderId="OID"+s_orderId;
            UserId=userId;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public enum OrderStatus{Purchased,Cancelled}
    public class OrderDetails
    {
        private static int _orderId=2000;
        public string OrderId{get;set;}
        public string UserId{get;set;}
        public string MedicineId{get;set;}
        public int MedicineCount{get;set;}
        public double TotalPrice{get;set;}
        public DateTime OrderDate{get;set;}
        public OrderStatus OrderStatus{get;set;}
        public OrderDetails(string userId,string medicineId,int medicineCount,double totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            _orderId++;
            OrderId="OID"+_orderId;
            UserId=userId;
            MedicineId=medicineId;
            MedicineCount=medicineCount;
            TotalPrice=totalPrice;
            OrderDate=orderDate;
            OrderStatus=orderStatus;
        }
    }
}
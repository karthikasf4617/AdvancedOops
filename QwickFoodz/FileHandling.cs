using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class FileHandling
    {
        //creating Folder
        public static void create()
        {
           if(!Directory.Exists("QwickFoodz"))
           {
            Console.WriteLine("Creating Folder...");
            Directory.CreateDirectory("QwickFoodz");
           }
           else
           {
            Console.WriteLine("Folder already exixts..");
           }
           if(!File.Exists("QwickFoodz/OrderDetails.csv"))
           {
            Console.WriteLine("Creating File..");
            File.Create("QwickFoodz/OrderDetails.csv");
           }
           else
           {
            Console.WriteLine("File Already Exists.");
           }
            if(!File.Exists("QwickFoodz/FoodDetails.csv"))
           {
            Console.WriteLine("Creating File..");
            File.Create("QwickFoodz/FoodDetails.csv");
           }
           else
           {
            Console.WriteLine("File Already Exists.");
           }
            if(!File.Exists("QwickFoodz/CustomerDetails.csv"))
           {
            Console.WriteLine("Creating File..");
            File.Create("QwickFoodz/CustomerDetails.csv");
           }
           else
           {
            Console.WriteLine("File Already Exists.");
           }
           if(!File.Exists("QwickFoodz/ItemDetails.csv"))
           {
            Console.WriteLine("Creating File..");
            File.Create("QwickFoodz/ItemDetails.csv");
           }
           else
           {
            Console.WriteLine("File Already Exists.");
           }
           
        }
        public static void WriteToCsv()
        {
            string[] customer=new string[Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                customer[i]=Operations.customerList[i].Name+","+Operations.customerList[i].FatherName+","+Operations.customerList[i].Gender+","+Operations.customerList[i].Mobile+","+Operations.customerList[i].DOB+","+Operations.customerList[i].MailID+","+Operations.customerList[i].Location+","+Operations.customerList[i].WalletBalance;

            }
            File.WriteAllLines("QwickFoodz/CustomerDetails.csv",customer);
            string[] food=new string[Operations.foodList.Count];
            for(int i=0;i<Operations.foodList.Count;i++)
            {
                food[i]=Operations.foodList[i].FoodId+","+Operations.foodList[i].FoodName+","+Operations.foodList[i].PricePerQuantity+","+Operations.foodList[i].QuantityAvalible;
            } 
            File.WriteAllLines("QwickFoodz/FoodDetails.csv",food);
            string[] item=new string[Operations.itemList.Count];
            for(int i=0;i<Operations.itemList.Count;i++)
            {
                item[i]=Operations.itemList[i].OrderId+","+Operations.itemList[i].FoodId+","+Operations.itemList[i].PurchaseCount+","+Operations.itemList[i].PriceOfOrder;
            }
            File.WriteAllLines("QwickFoodz/ItemDetails.csv",item);
            string[] order=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                order[i]=Operations.orderList[i].OrderId+","+Operations.orderList[i].CustomerId+","+Operations.orderList[i].TotalPrice+","+Operations.orderList[i].DateOfOrder+","+Operations.orderList[i].TotalPrice;
            }
            File.WriteAllLines("QwickFoodz/OrderDetails.csv",order);
        }
        public static void ReadFromCsv()
        {
           string[] customer=File.ReadAllLines("QwickFoodz/CustomerDetails.csv");
            foreach(string customer1 in customer)
            {
                CustomerDetails customer2=new CustomerDetails( customer1);
                Operations.customerList.Add(customer2);
            }
            string[] food=File.ReadAllLines("QwickFoodz/FoodDetails.csv");
            foreach(string food1 in food)
            {
                FoodDetails food2=new FoodDetails( food1);
                Operations.foodList.Add(food2);
            }
             string[] item=File.ReadAllLines("QwickFoodz/ItemDetails.csv");
            foreach(string item1 in item)
            {
                ItemDetails item2=new ItemDetails( item1);
                Operations.itemList.Add(item2);
            }
             string[] order=File.ReadAllLines("QwickFoodz/OrderDetails.csv");
            foreach(string order1 in order)
            {
                OrderDetails order2=new OrderDetails( order1);
                Operations.orderList.Add(order2);
            }
        }
    }
}
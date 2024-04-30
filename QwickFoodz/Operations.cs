using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class Operations
    {
        static CustomerDetails currentloggedinuser;
        static double totalprice;
        public static List<CustomerDetails> customerList=new List<CustomerDetails>();
        public  static List<FoodDetails> foodList=new List<FoodDetails>();
        public static List<OrderDetails> orderList=new List<OrderDetails>();
        public static List<ItemDetails> itemList=new List<ItemDetails>();
        //mainmaenu starts here
        public static void MainMenu()
        {
            Console.WriteLine("*********Welcome to Qwick**********");
            string option="yes";
            do
            {
                 
                Console.WriteLine("Select an Option\n1. Customer Registration \n2. Customer Login \n3. Exit");
                int MainOption=int.Parse(Console.ReadLine());
                switch(MainOption)
                {
                    case 1:
                    {
                        Console.WriteLine("***********CUSTOMER REGISTRATION***************");
                        CustomerRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("************Customer Login****************");
                        CustomerLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("**************Exiting Application******************");
                        option="no";
                        break;
                    }
                }
            }while(option =="yes");
        }
        //customerRegistartion starts here
        public static void CustomerRegistration()
        {
            Console.Write("Enter your Name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your Father Name : ");
            string fatherName=Console.ReadLine();
            Console.Write("Select your Gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your MobileNumber : ");
            string mobile=Console.ReadLine();
            Console.Write("Enter Your DOB");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your MailId : ");
            string mailId=Console.ReadLine();
            Console.Write("Enter your Location : ");
            string location=Console.ReadLine();
            Console.Write("Enter your Balance : ");
            double WalletBalance=double.Parse(Console.ReadLine());
            CustomerDetails customer=new CustomerDetails(name,fatherName,gender,mobile,dob,mailId,location,WalletBalance);
            customerList.Add(customer);
            Console.WriteLine("Customer registration successful Your Customer ID: "+customer.CustomerId);


        }
        public static void CustomerLogin()
        {
            Console.Write("Enter your LoginId : ");
            string loginId=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(CustomerDetails customer in customerList)
            {
                if(loginId.Equals(customer.CustomerId))
                {
                    currentloggedinuser=customer;
                    flag=false;
                    Console.WriteLine("Logged In Successfully..");
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Login Id..");
            }
        }
        public static void SubMenu()
        {
            Console.WriteLine("************SubMenu************");
            string option1="yes";
            do
            {
                
                Console.WriteLine("Select your Option..\n1. Show Profile\n2. OrderFood \n3. Cancel Order\n4. Modify Order \n5. Order History\n6. Recharge Wallet\n7. Show Wallet Balance\n8. Exit");
                int submenuOption=int.Parse(Console.ReadLine());
                switch(submenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("************Your Profile***************");
                        ShowProfile();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("************Order Food***************");
                        OrderFood();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("************Cancel Order***************");
                        CancelOrder();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("************Modify Order***************");
                        ModifyOrder();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("************Order History***************");
                        OrderHistory();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("************ Recharge Wallet***************");
                        RechargeWallet();
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine("************Show Wallet Balance***************");
                        ShowWalletBalance();
                        break;
                    }
                    case 8:
                    {
                        Console.WriteLine("************Exiting SubMenu***************");
                        option1="no";
                        break;
                    }

                }
            }while(option1=="yes");
        }
        public static void ShowProfile()
        {
            foreach(CustomerDetails customer in customerList)
            {
                if(customer.CustomerId.Equals(currentloggedinuser.CustomerId))
                {
                    Console.WriteLine($"{customer.CustomerId}|{customer.WalletBalance}|{customer.Name}|{customer.FatherName}|{customer.Gender}|{customer.Mobile}|{customer.DOB}|{customer.MailID}|{customer.Location}");
                }
            }
        }
         public static void OrderFood()
        {
            List<ItemDetails> localItemList=new List<ItemDetails>();
            OrderDetails order=new OrderDetails(currentloggedinuser.CustomerId,0,DateTime.Now,OrderStatus.Initiated);
            orderList.Add(order);
            string orderoption="yes";
            do
            {
                foreach(FoodDetails food in foodList)
                {
                    Console.WriteLine($"|{food.FoodId}|{food.FoodName}|{food.PricePerQuantity}|{food.QuantityAvalible}");
                }
                Console.Write("Select Food Id :");
                string foodId=Console.ReadLine().ToUpper();
                bool flag1=true;
                foreach(FoodDetails food1 in foodList)
                {
                    if(foodId.Equals(food1.FoodId))
                    {
                        flag1=false;
                        Console.Write("Enter the quantity :");
                        int orderquantity=int.Parse(Console.ReadLine());
                        bool flag=true;
                        if(orderquantity<=food1.QuantityAvalible)
                        {
                            flag=false;
                            double totalprice =orderquantity*food1.PricePerQuantity;
                            ItemDetails item=new ItemDetails(order.OrderId,food1.FoodId,orderquantity,totalprice);
                            localItemList.Add(item);
                            Console.WriteLine("Your order added to cart..");
                        }
                        else// if(flag)
                        {
                            
                            Console.WriteLine("Your entered quantity is not avalible..");
                            break;
                        }

                    }
                    else if(flag1)
                    {
                        Console.WriteLine("FoodId is Invalid..");
                        break;
                    }
                }
                Console.WriteLine("Do you want to continue..yes or no");
                orderoption=Console.ReadLine().ToLower();
            }while(orderoption=="yes");
            Console.Write("Do you want to Confirm purchase..");
            string orderconfirmoption=Console.ReadLine().ToLower();
            bool flag3=true;
            if(orderconfirmoption=="yes")
            {
                if(currentloggedinuser.WalletBalance>totalprice)
                {
                    flag3=false;
                    foreach(OrderDetails order1 in orderList)
                    {
                        if(currentloggedinuser.CustomerId.Equals(order1.CustomerId))
                        {
                            order1.OrderStatus=OrderStatus.Ordered;
                            order1.TotalPrice+=totalprice;
                            currentloggedinuser.DeductBalance(totalprice);
                            itemList.AddRange(localItemList);
                            Console.WriteLine("Order Placed Succesfully...Your OrderId : "+order1.OrderId);
                        }
                    }
                }
                else if(flag3)
                {
                    Console.WriteLine("Your wallennt balance is insufficient..Do you want to recharge ..yes or no");
                    string option2=Console.ReadLine().ToLower();
                    if(option2=="yes")
                    {
                        RechargeWallet();
                    }
                }
            }
            else
            {
                Console.WriteLine("cart Removed..");
            }

        }
         public static void CancelOrder()
        {
            foreach(OrderDetails order in orderList)
            {
                if(currentloggedinuser.CustomerId.Equals(order.CustomerId)&& order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    Console.WriteLine($"|{order.OrderId}|{order.CustomerId}|{order.DateOfOrder}|{order.TotalPrice}|");
                }
            }
            Console.Write("Choose OrderId : ");
            string orderid=Console.ReadLine().ToUpper();
            foreach(OrderDetails order in orderList)
            {
                if(orderid.Equals(order.OrderId))
                {
                    order.OrderStatus=OrderStatus.Cancelled;
                    order.TotalPrice-=totalprice;
                    Console.WriteLine("Your order Cancelled Successfully..");
                }
            }
        }
         public static void ModifyOrder()
        {
            foreach(OrderDetails order in orderList)
            {
                    Console.WriteLine($"|{order.OrderId}|{order.CustomerId}|{order.OrderStatus}|{order.TotalPrice}");
                
            }
            Console.Write("Select order Id to Modify : ");
            string orderId=Console.ReadLine().ToUpper();
            foreach(ItemDetails item in itemList)
            {
                if(orderId.Equals(item.OrderId))
                {
                    Console.WriteLine($"|{item.FoodId}|{item.OrderId}|{item.PriceOfOrder}|{item.PurchaseCount}|");

                }
            }
            Console.Write("Select ItemId to Modify");
            string modifyitem=Console.ReadLine();
            Console.Write("Enter New Quantity : ");
            int newquantity=int.Parse(Console.ReadLine());
            Console.WriteLine("Go you want add or decrease..Select option\n1. Add \n2. Decrease");
            int modifyOption=int.Parse(Console.ReadLine());
            switch(modifyOption)
            {
                case 1:
                {
                    foreach(OrderDetails order in orderList)
                    {
                        if(orderId.Equals(order.OrderId))
                        {
                            order.TotalPrice=totalprice*newquantity;
                            double newprice=totalprice*newquantity;
                            currentloggedinuser.WalletBalance-=newprice-totalprice;
                            if(currentloggedinuser.WalletBalance<=newprice)
                            {
                                Console.WriteLine("Your walletBalance is too low..Do you want to recharge yes or no");
                                string rechargeoption=Console.ReadLine();
                                if(rechargeoption=="yes")
                                {
                                     RechargeWallet();
                                }
                               
                            }
                            
                        }
                         
                         
                    }

                    break;
                }
                case 2:
                {
                    foreach(OrderDetails order in orderList)
                    {
                        if(orderId.Equals(order.OrderId))
                        {
                            order.TotalPrice*=newquantity;
                            double newprice=totalprice*newquantity;
                            currentloggedinuser.WalletBalance+=newprice-totalprice;
                            
                        }
                         
                         
                    }

                    break;
                }
            }
            Console.WriteLine($"{orderId} modifed successfully");
            
        }
         public static void OrderHistory()
        {
            foreach(OrderDetails order in orderList)
            {
                if(order.CustomerId.Equals(currentloggedinuser.CustomerId))
                {
                    Console.WriteLine($"|{order.OrderId}|{order.CustomerId}|{order.TotalPrice}|{order.DateOfOrder}");
                }
            }
        }
         public static void RechargeWallet()
        {
            Console.Write("Enter recharge amount : ");
            double recharge1=double.Parse(Console.ReadLine());
            double result=currentloggedinuser.WallteRecharge(recharge1);
            Console.WriteLine("Your Balance is : "+result);
        }
         public static void ShowWalletBalance()
        {
            Console.WriteLine("Your Wallet Balance is : "+currentloggedinuser.WalletBalance);
        }
        public static void AddDefaultData()
        {
            CustomerDetails customer1=new CustomerDetails("Ravi","Ettapparajan",Gender.Male,"974774646",new DateTime(11/11/1999),"	ravi@gmail.com","Chennai",10000);
            CustomerDetails customer2=new CustomerDetails("Baskaran","Sethurajan",Gender.Male,"847575775",new DateTime(11/11/1999),"	baskaran@gmail.com","Chennai",10000);
            customerList.AddRange(new List<CustomerDetails>{customer1,customer2});
            FoodDetails food1=new FoodDetails("Chicken Briyani 1Kg",	100,	12);
            FoodDetails food2=new FoodDetails("Mutton Briyani 1Kg",	150,	10);
            FoodDetails food3=new FoodDetails("Veg Full Meals",	80,	30);
            FoodDetails food4=new FoodDetails("Noodles",	100,	40);
            FoodDetails food5=new FoodDetails("Dosa",	40,	50);
            FoodDetails food6=new FoodDetails("Idly (2 pieces)",	20,	50);
            FoodDetails food7=new FoodDetails("Pongal",	40,	20);
            FoodDetails food8=new FoodDetails("Vegetable Briyani",	80,	15);
            FoodDetails food9=new FoodDetails("Lemon Rice",	50,	30);
            FoodDetails food10=new FoodDetails("Veg Pulav",	120,	30);
            FoodDetails food11=new FoodDetails("Chicken 65 (200 Grams)",75,	30);
            foodList.AddRange(new List<FoodDetails>{food1,food2,food3,food4,food5,food6,food7,food8,food9,food10,food11});
            OrderDetails order1=new OrderDetails(customer1.CustomerId,580,new DateTime(2022/11/26),OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails(customer2.CustomerId,870,new DateTime(2022/11/26),OrderStatus.Ordered);
            OrderDetails order3=new OrderDetails(customer1.CustomerId,820,new DateTime(2022/11/26),OrderStatus.Cancelled);
            orderList.AddRange(new List<OrderDetails>{order1,order2,order3});
            ItemDetails item1=new ItemDetails(order1.OrderId,food1.FoodId,2,200);
            ItemDetails item2=new ItemDetails(order1.OrderId,food2.FoodId,2,300);
            ItemDetails item3=new ItemDetails(order1.OrderId,food3.FoodId,1,80);
            ItemDetails item4=new ItemDetails(order2.OrderId,food1.FoodId,1,100);
            ItemDetails item5=new ItemDetails(order2.OrderId,food2.FoodId,4,600);
            ItemDetails item6=new ItemDetails(order2.OrderId,food10.FoodId,1,120);
            ItemDetails item7=new ItemDetails(order2.OrderId,food9.FoodId,1,50);
            ItemDetails item8=new ItemDetails(order1.OrderId,food2.FoodId,2,300);
            ItemDetails item9=new ItemDetails(order1.OrderId,food8.FoodId,4,300);
            ItemDetails item10=new ItemDetails(order1.OrderId,food1.FoodId,2,200);
            itemList.AddRange(new List<ItemDetails>{item1,item2,item3,item4,item5,item6,item7,item8,item9,item10});




        }
    }
}
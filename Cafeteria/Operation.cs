using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class Operation
    {
        static UserDetail currentLoggedInStudent;
        static CustomList<UserDetail>  UserDetailsList=new CustomList<UserDetail>();
        static CustomList<FoodDetails>  FoodDetailsList=new CustomList<FoodDetails>();
        static CustomList<OrderDetail>  OrderDetailsList=new CustomList<OrderDetail>();
        static CustomList<CartItem>  CartDetailsList=new CustomList<CartItem>();
        static CustomList<CartItem> CartItemList=new CustomList<CartItem>();
        private static object order;
        private static readonly int walletBalance;

        // Main Menu
        public static void MainMenu()
            {
                Console.WriteLine("*******Welcome*******");
                string mainchoice="yes";
                
               do
               {
                //Need to Show the Main menu option
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Exit\n");
                //Need to get an input from user and validate
                Console.Write("Select an option :");
                int mainoption=int.Parse(Console.ReadLine());

                 //Need to create mainmenu structure
                switch(mainoption)
                {
                    case 1:
                    {
                        Console.WriteLine("*******User Registration********");
                        UserRegistartion();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("********User Login********");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("**********Application Exited Successfully***********");
                        mainchoice ="no";
                        break;
                    }
                }
                //Need to iterate untill the option is exit.
                }while(mainchoice=="yes");
            }//Main Menu ends

            //student Registration
            public static void UserRegistartion()
            {
                //Need to get required details
                Console.Write("Enter Your Name : ");
                string name=Console.ReadLine();
                Console.Write("Enter your Father Name : ");
                string fatherName=Console.ReadLine();
                Console.Write("Enter your gender : ");
                Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.Write("Enter your MobileNumber : ");
                long mobile=long.Parse(Console.ReadLine());
                Console.Write("Enter you MailId : ");
                String mailId=Console.ReadLine();
                Console.Write("Enter your Workstation Number: ");
                String workstationNo=Console.ReadLine();
                Console.Write("Enter your Balance: ");
                int walletBalance=int.Parse(Console.ReadLine());

                //Need to crate an object
                UserDetail user=new UserDetail(name,fatherName,gender,mobile,mailId,workstationNo,walletBalance);
                //Need to add to list
                UserDetailsList.Add(user);
                //Need to display confirmation message and customerId
                Console.WriteLine($"You have successfully registered and your ID is {user.UserId}");

                //Need to create an object
                //Need to add in the list
                //Need to display confirmation message and Id

            }//User registration ends
            public static void UserLogin()
            {
                //need to get login input
                Console.Write("Enter your student ID : ");
                string loginId=Console.ReadLine().ToUpper();
                //validate by its presence in the list
                bool flag=true;
                foreach(UserDetail user in UserDetailsList)
                {
                    if(loginId.Equals(user.UserId))
                    {
                        flag=false;
                        //assign current use
                        currentLoggedInStudent=user;
                        Console.WriteLine("Logged in Successfully");
                        SubMenu();
                        break;
                        //Need to call submenu
                    }
                }
                if(flag)
                {
                    Console.WriteLine("Invalid User");
                }
                //if not-Invalid


            }
             //submenu
            public static void SubMenu()
            {
                string subChoice="yes";
                do{
                    Console.WriteLine("******SubMenu********");
                      //Need to show submenu options
                    Console.WriteLine("Select an option.\n1. Show My Profile \n2. Food Order\n3. Modify Order\n4. Cancel Order \n5. Order History \n6. Wallet Recharge\n7. Show Wallet Balance\n8. Exit");
                    //Getting user option
                    Console.Write("Enter your option :");
                    int subOption=int.Parse(Console.ReadLine());
                    //Need to create sub menu structure
                    switch(subOption)
                    {
                        case 1:
                        {
                            Console.WriteLine("************Show My Profile*************");
                            ShowMyProfile();
                            break;
                        }
                         case 2:
                        {
                            Console.WriteLine("**************Food Order**********");
                            FoodOrder();
                            break;
                        }
                         case 3:
                        {
                            Console.WriteLine("**************Modify Order**********");
                            ModifyOrder();
                            break;
                        }
                         case 4:
                        {
                            Console.WriteLine("***************Cancel Order*************");
                            CancelOrder();
                            break;
                        }
                         case 5:
                        {
                            Console.WriteLine("*************Order History**********");
                            OrderHistory();
                            break;
                        }
                         case 6:
                        {
                            Console.WriteLine("*************Wallet Recharge**********");
                            WalletRecharge();
                            break;
                        }
                         case 7:
                        {
                            Console.WriteLine("*************Show Wallet Balance**********");
                            ShowWalletBalance();
                            break;
                        }
                         case 8:
                        {
                            Console.WriteLine("**************Taking Back to Main Menu**********");
                            subChoice="no";
                            break;
                        }
                    }
                    //Iterate till the option is exit

                }while(subChoice=="yes");

            }//submenu ends
            public static void ShowMyProfile()
            {
            
                Console.WriteLine($"UserId : {currentLoggedInStudent.UserId} \nName : {currentLoggedInStudent.Name}\n FatherName : {currentLoggedInStudent.FatherName}\n Gender : :{currentLoggedInStudent.Gender}\n MobileNumber : {currentLoggedInStudent.Mobile}\n MailID : {currentLoggedInStudent.MailID} \n WorkstationNo : {currentLoggedInStudent.WorkStationNumber}\n WalletBalance : {currentLoggedInStudent.WalletBalance}");
            }
             public static void FoodOrder()
            {
                int TotalPrice=0;
                Console.WriteLine("Do you want to purchase the food:");
                string option=Console.ReadLine().ToLower();
                if(option=="yes")
                {
                    CustomList<CartItem> tempCartItemList=new CustomList<CartItem>();
                    OrderDetail order=new OrderDetail(currentLoggedInStudent.UserId,DateTime.Now,0,OrderStatus.Initiated);
                    OrderDetailsList.Add(order);
                    string choice="yes";
                    do
                    {
                        Console.WriteLine("|FoodId|FoodName|FoodPrice|Quantity|");
                        foreach(FoodDetails food in FoodDetailsList)
                        {
                            Console.WriteLine($"|{food.FoodId}|{food.FoodName}|{food.FoodPrice}|{food.AvalibleQuantity}");
                        }
                        Console.Write("Enter FoodId : ");
                        string foodid=Console.ReadLine().ToUpper();
                        foreach(FoodDetails food in FoodDetailsList)
                        {
                            if(foodid.Equals(food.FoodId))
                            {
                                 Console.WriteLine("Enter Quantity : ");
                                int Quantity=int.Parse(Console.ReadLine());
                                if(Quantity<=food.AvalibleQuantity)
                                {
                                    int Price=Quantity*food.FoodPrice;
                                    TotalPrice=TotalPrice+Price;
                                    food.AvalibleQuantity=food.AvalibleQuantity-Quantity;
                                    CartItem food1=new CartItem(order.OrderId,food.FoodId,Price,Quantity);
                                    tempCartItemList.Add(food1);
                                    Console.WriteLine("Order Placed Successfully.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You are asking out of the count range....");
                                }
                            }
                        }
                        Console.WriteLine("Do you want to continue");
                        choice=Console.ReadLine().ToLower();
               
                    }while(choice=="yes");
                }
                Console.WriteLine("Do you want to confirm the order..");
                string Option1=Console.ReadLine().ToLower();
                if(Option1=="yes")
                {
                    do
                    {
                        if(currentLoggedInStudent.WalletBalance>=TotalPrice)
                        {
                            currentLoggedInStudent.DeductAmount(TotalPrice);
                            Console.WriteLine("Balance is Deducted...."+currentLoggedInStudent.WalletBalance);
                            Console.WriteLine("Order was sccessful..");
                            Option1="no";
                        }
                        else
                        {
                            Console.WriteLine("InsufficientBalance ");
                            Console.WriteLine("Do you want  to Recharge ..");
                            string option2=Console.ReadLine().ToLower();
                            if(option2=="yes")
                            {
                                Console.WriteLine("Enter the amount..");
                                int amount2=int.Parse(Console.ReadLine());
                                currentLoggedInStudent.WalletRecharge(amount2);
                                Console.WriteLine("Recharge Successful..");
                            }
                            else if(option2=="no")
                            {
                                Console.WriteLine("Thank you");
                            }
                        }
                    }while(Option1=="yes");
                }
            }
             public static void ModifyOrder()
            {
                bool flag=true;
                foreach(OrderDetail order in OrderDetailsList)
                {
                    if(currentLoggedInStudent.UserId==order.UserId&& order.OrderStatus==OrderStatus.Ordered)
                    {
                        flag=false;
                        Console.WriteLine($"|{order.OrderId}|{order.UserId}|{order.TotalPrice}|{order.OrderStatus}");
                    }
                }
                if(flag)
                {
                    Console.WriteLine("No History found");
                }
                Console.WriteLine("Choose order id");
                string orderid=Console.ReadLine().ToUpper();
                foreach(OrderDetail order1 in OrderDetailsList)
                {
                    if(orderid==order1.OrderId && currentLoggedInStudent.UserId==order1.UserId&& order1.OrderStatus==OrderStatus.Ordered)
                    {
                        foreach(CartItem cart in CartItemList)
                        {
                            if(cart.OrderId==orderid)
                            {
                                Console.WriteLine($"|{cart.ItemId}|{cart.OrderId}|{cart.FoodId}|{cart.OrderPrice}|{cart.OrderQuantity}");

                            }
                        }
                        Console.WriteLine("Enter the Item ID");
                        String useritemid=Console.ReadLine().ToUpper();
                        foreach(CartItem cart in CartItemList)
                        {
                            if(useritemid==cart.ItemId && currentLoggedInStudent.UserId==order1.UserId)
                            {
                                Console.WriteLine("Enter the quantity of food:");
                                int newquantity=int.Parse(Console.ReadLine());
                                foreach(FoodDetails food in FoodDetailsList)
                                {
                                    if(food.FoodId.Equals(cart.FoodId))
                                    {
                                        Console.WriteLine("Choose to add or sub");
                                        string option=Console.ReadLine().ToLower();
                                        if(option=="yes")
                                        {
                                            if(food.AvalibleQuantity>newquantity)
                                            {
                                                int newprice=food.FoodPrice*newquantity;
                                                cart.OrderPrice+=newprice;
                                                cart.OrderQuantity+=newquantity;
                                                order1.TotalPrice+=cart.OrderPrice;
                                                food.AvalibleQuantity-=newquantity;
                                                currentLoggedInStudent.DeductAmount(newprice);
                                                Console.WriteLine("Moddified successfully");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            int newprice=food.FoodPrice*newquantity;
                                            cart.OrderPrice-=newprice;
                                            cart.OrderQuantity-=newquantity;
                                            order1.TotalPrice-=cart.OrderPrice;
                                            food.AvalibleQuantity+=newquantity;
                                            Console.WriteLine("Modified successfully");
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
             public static void CancelOrder()
            {
                bool flag=true;
                foreach(OrderDetail order in OrderDetailsList)
                {
                    if(currentLoggedInStudent.UserId.Equals(order.UserId))
                    {
                        flag=false;
                        Console.WriteLine($"|{order.OrderId}|{order.UserId}|{order.OrderDate}|{order.TotalPrice}|{order.OrderStatus}");

                    }
                }
                if(flag)
                {
                    Console.WriteLine("No purchsse found");
                }
                if(flag)
                {
                    Console.WriteLine("Enter the orderId to cancel");
                    string orderId=Console.ReadLine().ToUpper();
                     flag=true;
                     foreach(OrderDetail order in OrderDetailsList)
                     {
                        flag=false;
                        if(currentLoggedInStudent.UserId.Equals(order.UserId)&& order.OrderStatus==OrderStatus.Ordered&&orderId.Equals(order.OrderId))
                        {
                            currentLoggedInStudent.WalletRecharge(order.TotalPrice);
                            order.OrderStatus=OrderStatus.Cancelled;
                            Console.WriteLine("your order is cancelled ...");
                           
                        }
                     }
                     if(flag)
                     {
                        Console.WriteLine("Invalid OrderId");
                     }

                }
            }
             public static void OrderHistory()
            {
                Console.WriteLine("|OrderId|UserId|OrderDate|TotalPrice|OrderStatus|");
                foreach(OrderDetail order in OrderDetailsList)
                {
                    if(order.UserId.Equals(currentLoggedInStudent.UserId))
                    {
                        Console.WriteLine($"|{order.OrderId}|{order.UserId}|{order.OrderDate}|{order.TotalPrice}|{order.OrderStatus}");
                    }
                }
            }
             public static void WalletRecharge()
            {
                Console.Write("Enter Recharge Amount ");
                int Recharge=int.Parse(Console.ReadLine());
                int result=currentLoggedInStudent.WalletRecharge(Recharge);
                Console.WriteLine("Your Balance : "+currentLoggedInStudent.WalletBalance);
            }
             public static void ShowWalletBalance()
            {
                Console.WriteLine("Your WalletBalance : "+currentLoggedInStudent.WalletBalance);
            }

            //Adding DefaultData
            public static void AddDefaultData()
            {
                UserDetail user1=new UserDetail("Ravichandran","Ettapparajan",Gender.Male,8857777575,"ravi@gmail.com","WS101",400);
                UserDetail user2=new UserDetail("Baskaran","Sethurajan"	,Gender.Male,9577747744,"baskaran@gmail.com","WS105",500);
                UserDetailsList.Add(user1);
                UserDetailsList.Add(user2);
                FoodDetails food1=new FoodDetails("Coffee",20,100);
                FoodDetails food2=new FoodDetails("Tea",15,100);
                FoodDetails food3=new FoodDetails("Biscuit",10,100);
                FoodDetails food4=new FoodDetails("Juice",50,100);
                FoodDetails food5=new FoodDetails("Puff",40,100);
                FoodDetails food6=new FoodDetails("Milk",10,100);
                FoodDetails food7=new FoodDetails("Popcorn",20,20);
                FoodDetailsList.Add(food1);
                FoodDetailsList.Add(food2);
                FoodDetailsList.Add(food3);
                FoodDetailsList.Add(food4);
                FoodDetailsList.Add(food5);
                FoodDetailsList.Add(food6);
                FoodDetailsList.Add(food7);
                OrderDetail order1=new OrderDetail(user1.UserId,new DateTime(2022/06/19),70,OrderStatus.Ordered);
                OrderDetail order2=new OrderDetail(user2.UserId,new DateTime(2022/06/15),100,OrderStatus.Ordered);
                OrderDetailsList.Add(order1);
                OrderDetailsList.Add(order1);
                CartItem cart1=new CartItem(order1.OrderId,food1.FoodId,20,1);
                CartItem cart2=new CartItem(order1.OrderId,food2.FoodId,20,1);
                CartItem cart3=new CartItem(order1.OrderId,food3.FoodId,40,1);
                CartItem cart4=new CartItem(order2.OrderId,food1.FoodId,10,1);
                CartItem cart5=new CartItem(order2.OrderId,food4.FoodId,10,1);
                CartItem cart6=new CartItem(order2.OrderId,food6.FoodId,50,1);
                CartItem cart7=new CartItem(order2.OrderId,food7.FoodId,40,1);
                CartDetailsList.Add(cart1);
                CartDetailsList.Add(cart2);
                CartDetailsList.Add(cart3);
                CartDetailsList.Add(cart4);
                CartDetailsList.Add(cart5);
                CartDetailsList.Add(cart6);
                CartDetailsList.Add(cart7);
            }

    }
}
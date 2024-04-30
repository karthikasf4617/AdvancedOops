using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operations
    {
        static UserDetails currentLoggedInUser;
        public static List<UserDetails> userList=new List<UserDetails>();
        public static List<MedicineDetails> medicineList=new List<MedicineDetails>();
        public static List<OrderDetails> orderList=new List<OrderDetails>();
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
        public static void UserRegistartion()
        {
            Console.Write("Enter Your Name : ");
                string name=Console.ReadLine();
                Console.Write("Enter your age : ");
                int age=int.Parse(Console.ReadLine());
                Console.Write("Enter your City: ");
                string city=Console.ReadLine();
                Console.Write("Enter your MobileNumber : ");
                long PhoneNumber=long.Parse(Console.ReadLine());
                Console.Write("Enter your Balance: ");
                double Balance=double.Parse(Console.ReadLine());
                UserDetails user=new UserDetails(name,age,city,PhoneNumber,Balance);
                userList.Add(user);
                Console.WriteLine("Account is created..Your Id is : "+user.UserId);

        }
        public  static void UserLogin()
        {
            //need to get login input
                Console.Write("Enter your student ID : ");
                string loginId=Console.ReadLine().ToUpper();
                //validate by its presence in the list
                bool flag=true;
                foreach(UserDetails user in userList)
                {
                    if(loginId.Equals(user.UserId))
                    {
                        flag=false;
                        //assign current use
                        currentLoggedInUser=user;
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
        }
        public static void SubMenu()
            {
                string subChoice="yes";
                do{
                    Console.WriteLine("******SubMenu********");
                      //Need to show submenu options
                    Console.WriteLine("Select an option.\n1. Show Medicine List M \n2.Purchase Medicine\n3. Modify Purchase\n4. Cancel Purchase \n5. Show Purchase History\n6. Wallet Recharge\n7. Show Wallet Balance\n8. Exit");
                    //Getting user option
                    Console.Write("Enter your option :");
                    int subOption=int.Parse(Console.ReadLine());
                    //Need to create sub menu structure
                    switch(subOption)
                    {
                        case 1:
                        {
                            Console.WriteLine("************Show Medicine List*************");
                            ShowMedicineList();
                            break;
                        }
                         case 2:
                        {
                            Console.WriteLine("**************Purchase Medicine**********");
                            PurchaseMedicine();
                            break;
                        }
                         case 3:
                        {
                            Console.WriteLine("**************Modify Purchase**********");
                            ModifyPurchase();
                            break;
                        }
                         case 4:
                        {
                            Console.WriteLine("***************Cancel Purchase*************");
                            CancelPurchase();
                            break;
                        }
                         case 5:
                        {
                            Console.WriteLine("*************Show Purchase History**********");
                            ShowPurchaseHistory();
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
        public static void ShowMedicineList()
        {
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"|{medicine.MedicineId}|{medicine.MedicineName}|{medicine.AvalibleCount}|{medicine.Price}|{medicine.DateOfExpiry}");
            }
        }
        public static void PurchaseMedicine()
        {
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"|{medicine.MedicineId}|{medicine.MedicineName}|{medicine.AvalibleCount}|{medicine.Price}|{medicine.DateOfExpiry}");
            }
            Console.Write("Enter Medicine Id : ");
            string medicineId=Console.ReadLine();
            foreach(MedicineDetails medicine1 in medicineList)
            {
                if(medicineId.Equals(medicine1.MedicineId))
                {
                    Console.Write("Enter the count : ");
                    int medicinecount=int.Parse(Console.ReadLine());
                    if(medicinecount<=medicine1.AvalibleCount)
                    {
                        int result=DateTime.Now.CompareTo(medicine1.DateOfExpiry);
                        if(result<0)
                        {
                            if(currentLoggedInUser.WalletBalance>=medicine1.Price)
                            {
                                double Totalamount=medicinecount*medicine1.Price;
                                medicine1.AvalibleCount-=medicinecount;
                                currentLoggedInUser.WalletBalance-=Totalamount;
                                OrderDetails order=new OrderDetails(currentLoggedInUser.UserId,medicineId,medicinecount,Totalamount,DateTime.Now,OrderStatus.Purchased);
                                orderList.Add(order);
                                Console.WriteLine("Medicine was purchased Successfully..");


                            }
                            else
                            {
                                Console.WriteLine("Your Balnce is too low");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Medicine is expired..");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your entered count is not avalible..");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid medicine id..");
                }
            }


        }

        public static void ModifyPurchase()
        {
            
        }
        public static void CancelPurchase()
        {
            
        }
        public static void ShowPurchaseHistory()
        {
            
        }
        public static void WalletRecharge()
        {
            
        }
        public static void ShowWalletBalance()
        {
            
        }




        public static void AddDefaultData()
        {
            UserDetails user1=new UserDetails("Ravi",33	,"Theni",	9877774440	,400);
            UserDetails user2=new UserDetails("Baskaran",	33,	"Chennai",	8847757470	,500);
            userList.AddRange(new List<UserDetails>{user1,user2});
            MedicineDetails medicine1=new MedicineDetails("Paracitamol",40,5,new DateTime(30/06/2024));
            MedicineDetails medicine2=new MedicineDetails("Calpol",10,5,new DateTime(30/05/2024));
            MedicineDetails medicine3=new MedicineDetails("Gelucil",3,40,new DateTime(30/04/2023));
            MedicineDetails medicine4=new MedicineDetails("Metrogel",5,50,new DateTime(30/12/2024));
            MedicineDetails medicine5=new MedicineDetails("Povidin Iodin",10,50,new DateTime(30/10/2024));
            medicineList.AddRange(new List<MedicineDetails>{medicine1,medicine2,medicine3,medicine4,medicine5});
            OrderDetails order1=new OrderDetails(user1.UserId,medicine1.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Purchased);
            OrderDetails order2=new OrderDetails(user2.UserId,medicine2.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Cancelled);
            OrderDetails order3=new OrderDetails(user1.UserId,medicine3.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Purchased);
            OrderDetails order4=new OrderDetails(user1.UserId,medicine4.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Cancelled);
            OrderDetails order5=new OrderDetails(user1.UserId,medicine5.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Purchased);
             OrderDetails order6=new OrderDetails(user1.UserId,medicine5.MedicineId,3,15,new DateTime(13/11/2022),OrderStatus.Purchased);
             orderList.AddRange(new List<OrderDetails>{order1,order2,order3,order4,order5,order6});
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class Operations
    {
        public static string CurrentLoginUser;     
        static List<UserDetails> userDetailsList=new List<UserDetails>();
        static List<BookDetails> bookDetailsList=new List<BookDetails>();
        static List<BorrowDetails> borrowDetailsList=new List<BorrowDetails>();
         public static void AddDefault()
        {
            UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Department.EEE,9938388333,"ravi@gmail.com",100);
            UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Department.CSE,9944444455,"priya@gmail.com",150);
            userDetailsList.AddRange(new List<UserDetails>{user1,user2});
            BookDetails book1=new BookDetails("C#","Author1",	3);
            BookDetails book2=new BookDetails("HTML","Author2",5);
            BookDetails book3=new BookDetails("CSS"	,"Author1",3);
            BookDetails book4=new BookDetails("JS","Author1",3);
            BookDetails book5=new BookDetails("TS","Author2",2);
            bookDetailsList.AddRange(new List<BookDetails>{book1,book2,book3,book4,book5});
            BorrowDetails borrow1=new BorrowDetails(book1.BookId,user1.UserId,new DateTime(2023/09/10),2,Status.Borrowed,0);
            BorrowDetails borrow2=new BorrowDetails(book2.BookId,user2.UserId,new DateTime(2023/09/12),1,Status.Borrowed,0);
            BorrowDetails borrow3=new BorrowDetails("BID1004","SF3001",new DateTime(2023/09/14),1,Status.Returned,16);
            BorrowDetails borrow4=new BorrowDetails("BID1002","SF3002",new DateTime(2023/09/11),2,Status.Borrowed,0);
            BorrowDetails borrow5=new BorrowDetails("BID1005","SF3002",new DateTime(2023/09/09),1,Status.Returned,20);
            borrowDetailsList.AddRange(new List<BorrowDetails>{borrow1,borrow2,borrow3,borrow4,borrow5});
        }
        public static void MainMenu()
        {
            Console.WriteLine("************WELCOME TO SYNCFUSION LIBRARAY****************");
            string option="yes";
            do{
                Console.WriteLine("Select Your Option  \n1. User Registartion \n2. User Login \n3. Exit");
                int mainoption=int.Parse(Console.ReadLine());
                switch(mainoption)
                {
                    case 1:
                    {
                        Console.WriteLine("***************USER REGISTRATION**************");
                        UserRegistartion();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**************User Login*******************");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("******************Thank You for Visiting********************");
                        option="no";
                        break;
                    }
                }

            }while(option=="yes");
        }
        public static void UserRegistartion()
        {
            Console.Write("Enter your Name : ");
            string userName=Console.ReadLine();
            Console.Write("Select your Gender : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Select your Department : ");
            Department department=Enum.Parse<Department>(Console.ReadLine(),true);
            Console.Write("Enter your Mobile Number : ");
            long mobileNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter your MailId : ");
            string mailId=Console.ReadLine();
            Console.Write("Enter your WalletBalance : ");
            long walletBalance=long.Parse(Console.ReadLine());
            UserDetails user=new UserDetails(userName,gender,department,mobileNumber,mailId,walletBalance);
            userDetailsList.Add(user);
            Console.WriteLine($"You have successfully Registered .. And Your Id is{user.UserId}");

        }
        public static void UserLogin()
        {
            Console.WriteLine("*************Login Page**************");
            Console.Write("Enter your LoginId :");
            string loginId=Console.ReadLine().ToUpper();
            CurrentLoginUser=loginId;
            bool flag=true;
            foreach(UserDetails user in userDetailsList)
            {
                if(loginId.Equals(user.UserId))
                {
                    flag=false;
                    Console.WriteLine("***********Logged In Successfulyy***********");
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid User Id");
            }
        }
        public static void SubMenu()
        {
            Console.WriteLine("*************SubMenu*************");
            string option1="yes";
            do{
                Console.WriteLine("Select Your Option :\n1. Borrow Book \n2. Show Borrowed History \n3. Return Books\n4. Wallet Recharge \n5. Exit");
                int submenuOption=int.Parse(Console.ReadLine());
                switch(submenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*******Borrow Book **********");
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*******Borrowed History**********");
                        ShowBorrowedHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*******Returning Books**********");
                        ReturnBooks();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*******Wallet Recharge**********");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("*******Exiting SubMenu**********");
                        option1="no";
                        break;
                    }
                }

            }while(option1=="yes");
        }
        public static void BorrowBook()
        {
            Console.WriteLine("|BOOK ID | BOOK NAME | AUTHOR NAME | BOOK COUNT |");
            foreach(BookDetails borrow in bookDetailsList)
            {
                
                Console.WriteLine($"|{borrow.BookId}|{borrow.BookName}|{borrow.AuthorName}|{borrow.BookCount}");
            }
            Console.Write("Enter Book Id to Borrow : ");
            string bookid=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(BookDetails book in bookDetailsList)
            {
                if(bookid.Equals(book.BookId) && book.BookCount>0)
                {
                    flag=false;
                    Console.Write("Enter Count of the book to borrow : ");
                    int borrowcount=int.Parse(Console.ReadLine());
                    if(borrowcount>book.BookCount)
                    {
                        Console.WriteLine("Books are not avalible for the enetered bookcount .");
                    }
                    else if(borrowcount<book.BookCount)
                    {
                        foreach(BorrowDetails borrow in borrowDetailsList)
                        {
                            if(borrow.BorrowBookCount==3)
                            {
                                Console.WriteLine("You have borrowed 3 books already ");
                            }
                            else if(borrow.BorrowBookCount>3)
                            {
                                Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {borrow.BorrowBookCount} and requested count is {borrowcount}, which exceeds 3 ");
                            }
                            else
                            {
                                foreach(BorrowDetails borrow2 in borrowDetailsList)
                                {
                                    if(bookid.Equals(book.BookId))
                                    {
                                        borrow2.Status=Status.Borrowed;
                                        borrow2.BorrowedDate=DateTime.Now;
                                        borrow2.PaidFineAmount=0;
                                        BorrowDetails borrowobj=new BorrowDetails(borrow.BorrowId,book.BookId,borrow2.BorrowedDate,borrow.BorrowBookCount,borrow2.Status,borrow2.PaidFineAmount);
                                    }
                                }
                            }
                        }
                    }

                }
                if(flag)
                {
                    Console.WriteLine("Invalid Book ID");
                }
            }

        }
        public static void ShowBorrowedHistory()
        {
            foreach(BorrowDetails borrow in borrowDetailsList)
            {
                if(CurrentLoginUser.Equals(borrow.UserId))
                {
                    Console.WriteLine("|Borrow Id|BookId| User Id| BorrowBookCount|Status|PaidFineAmount|");
                    Console.WriteLine($"|{borrow.BorrowId}|{borrow.BookId}|{borrow.UserId}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                }
            }

        }
        public static void ReturnBooks()
        {

        }
        public static void WalletRecharge()
        {
            Console.Write("Do you want to Recharge Your Wallet :");
            string rechargeoption=Console.ReadLine().ToLower();
            bool flag=true;
            if(rechargeoption=="yes")
            {
                flag=false;
                Console.Write("Enter amount to be recharged : ");
                long rechargeAmount=long.Parse(Console.ReadLine());
                //UserDetails.Recharge(recharge);
            }
            else if(flag)
            {
                SubMenu();
            }
        }

       
    }
}
    
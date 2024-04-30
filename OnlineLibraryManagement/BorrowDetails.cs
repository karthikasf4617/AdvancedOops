using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum Status{Default,Borrowed,Returned}
    public class BorrowDetails
    {
        private static int s_borrowId=2000;
        public string BorrowId{get;}
        public string BookId{get;set;}
        public string UserId{get;set;}
        public DateTime BorrowedDate{get;set;}
        public int BorrowBookCount{get;set;}
        public Status Status{get; set;}
        public double PaidFineAmount{get;set;}

        public BorrowDetails(string bookId,string userId,DateTime borrowedDate,int borrowBookCount,Status status,double paidFineAmount)
        {
            s_borrowId++;
            string BorrowId="LB"+s_borrowId;
            BookId=bookId;
            UserId=userId;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }

    }
}
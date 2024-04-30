using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        private static int _medicineId=100;
        public string MedicineId{get;set;}
        public string MedicineName{get;set;}
        public int AvalibleCount{get;set;}
        public double Price{get;set;}
        public DateTime DateOfExpiry{get;set;}
        public MedicineDetails(string medicineName,int avalibleCount,double price,DateTime dateOfExpiry)
        {
            _medicineId++;
            MedicineId="MD"+_medicineId;
            MedicineName=medicineName;
            AvalibleCount=avalibleCount;
            Price=price;
            DateOfExpiry=dateOfExpiry;
        }
    }
}
using System;
namespace QwickFoodz
{
    class Program 
    {
        public static void Main(string[] args)
        {
            FileHandling.create();
            FileHandling.WriteToCsv();
            Operations.AddDefaultData();
            Operations.MainMenu();
        }
    }
}
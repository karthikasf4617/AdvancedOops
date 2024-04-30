using System;
namespace Interfaces1
{
    class Program 
    {
        public static void Main(string[] args)
        {
            Dog dog=new Dog();
            dog.Name="Golden";
            dog.Habitat="Walking";
            dog.EatingHabit="Biscuit";
            dog.DisplayName();
            Duck duck=new Duck();
            duck.Name="Gold";
            duck.Habitat="Walking";
            duck.EatingHabit="Insects";
            duck.DisplayName();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces1
{
    public class Duck:IAnimal
    {
       public string Name{get;set;}
       public string Habitat{get;set;}
       public string EatingHabit{get;set;}
       public void DisplayName()
       {
         Console.WriteLine($"Name :{Name}\nHabitat : {Habitat}\nEatingHabit : {EatingHabit}");
       }
    }
}
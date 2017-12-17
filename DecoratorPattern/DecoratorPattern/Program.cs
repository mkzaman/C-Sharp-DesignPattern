using DecoratorPattern.Beverages;
using DecoratorPattern.Condiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args) 
        {
            Beverage beverage = new Espresso();
            Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());

            Beverage darkRoast = new DarkRoast();
            darkRoast = new Mocha(darkRoast);
            darkRoast = new Mocha(darkRoast);
            darkRoast = new Whip(darkRoast);
            Console.WriteLine(darkRoast.GetDescription() + " $" + darkRoast.Cost());

            Beverage houseBlend = new HouseBlend();
            houseBlend = new Soya(houseBlend);
            houseBlend = new Mocha(houseBlend);
            houseBlend = new Whip(houseBlend);
            Console.WriteLine(houseBlend.GetDescription() + " $" + houseBlend.Cost());

        }
    }
}

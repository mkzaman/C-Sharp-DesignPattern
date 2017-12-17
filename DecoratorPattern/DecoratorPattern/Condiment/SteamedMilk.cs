using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Condiment
{
    public class SteamedMilk : CondimentDecorator
    {
        Beverage beverage;

        public SteamedMilk(Beverage beverage)
        {
            this.beverage = beverage;
            Description = beverage.GetDescription() + ", Steamed Milk";
        }

        public override double Cost()
        {
            return 0.10 + beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Steamed Milk";
        }
    }
}

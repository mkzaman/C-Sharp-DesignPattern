using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Condiment
{
    public class Soya : CondimentDecorator
    {
        Beverage beverage;

        public Soya(Beverage beverage)
        {
            this.beverage = beverage;
            Description = beverage.GetDescription() + ", Soya";
        }

        public override double Cost()
        {
            return 0.15 + beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soya";
        }
    }
}

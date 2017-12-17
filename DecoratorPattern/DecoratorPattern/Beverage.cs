using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class Beverage
    {
        public string Description = "Unknown Beverage";

        public string GetDescription()
        {
            return Description;
        }

        public abstract double Cost();
    }
}

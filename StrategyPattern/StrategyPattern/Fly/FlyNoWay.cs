using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Fly
{
    class FlyNoWay : IFlyingBehaviors
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
}

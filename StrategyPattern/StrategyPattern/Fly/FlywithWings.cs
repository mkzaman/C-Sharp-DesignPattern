using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Fly
{
    public class FlywithWings : IFlyingBehaviors
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Fly
{
    public class FlyRocketPowered : IFlyingBehaviors
    {
        public void Fly()
        {
            Console.WriteLine("I Fly with a Rocket");
        }
    }
}

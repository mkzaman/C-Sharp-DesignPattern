using StrategyPattern.Fly;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Duck
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack.Quack();
            flyingBehaviors = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard Duck");
        }
    }
}

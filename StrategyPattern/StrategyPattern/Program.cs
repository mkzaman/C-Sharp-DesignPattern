using StrategyPattern.Duck;
using System;
using StrategyPattern.Fly;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck mallardDuck = new MallardDuck();
            mallardDuck.Display();
            mallardDuck.PerformFly();
            mallardDuck.SetFlyingBehavior(new FlyRocketPowered());
            mallardDuck.PerformFly();
            mallardDuck.PerformQuack();
            mallardDuck.Swim();
        }
    }
}
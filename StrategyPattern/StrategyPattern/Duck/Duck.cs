using StrategyPattern.Fly;
using StrategyPattern.Quack;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Duck
{
    public abstract class Duck
    {
        protected IFlyingBehaviors flyingBehaviors;
        protected IQuackBehavior quackBehavior;
        
        public Duck()
        {

        }

        public abstract void Display();

        public void PerformFly()
        {
            flyingBehaviors.Fly();
        }

        public void PerformQuack()
        {
            quackBehavior.Quack();
        }

        public void SetFlyingBehavior(IFlyingBehaviors flyingBehaviors)
        {
            this.flyingBehaviors = flyingBehaviors;
        }

        public void SetQuackBehavior(IQuackBehavior quackBehavior)
        {
            this.quackBehavior = quackBehavior;
        }

        public void Swim()
        {
            Console.WriteLine("All ducks can swim, even decoys");
        }
    }
}

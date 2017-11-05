using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Quack
{
    class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<<Silence>>");
        }
    }
}

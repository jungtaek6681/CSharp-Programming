using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Basic
{
    internal class Dungeon : IEnterable
    {
        public void Enter()
        {
            Console.WriteLine("던전에 들어갑니다.");
        }

        public void Exit()
        {
            Console.WriteLine("던전에서 나옵니다.");
        }
    }
}

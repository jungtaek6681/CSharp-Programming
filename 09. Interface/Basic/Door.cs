using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Basic
{
    internal class Door : IOpenable, IEnterable
    {
        public void Open()
        {
            Console.WriteLine("문이 열립니다.");
        }

        public void Close()
        {
            Console.WriteLine("문이 닫힙니다.");
        }

        public void Enter()
        {
            Console.WriteLine("문에 들어갑니다.");
        }

        public void Exit()
        {
            Console.WriteLine("문에서 나옵니다.");
        }
    }
}

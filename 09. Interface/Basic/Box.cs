using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Basic
{
    internal class Box : IOpenable
    {
        public void Open()
        {
            Console.WriteLine("박스가 열립니다.");
        }

        public void Close()
        {
            Console.WriteLine("박스가 닫힙니다.");
        }
    }
}

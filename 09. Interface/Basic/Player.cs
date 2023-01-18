using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Basic
{
    internal class Player
    {
        public void Enter(IEnterable enterable)
        {
            Console.WriteLine("플레이어가 " + enterable.ToString() + "에 들어가기를 시도합니다.");
            enterable.Enter();
        }

        public void Exit(IEnterable enterable)
        {
            Console.WriteLine("플레이어가 " + enterable.ToString() + "에 나가기를 시도합니다.");
            enterable.Exit();
        }

        public void Open(IOpenable openable)
        {
            Console.WriteLine("플레이어가 " + openable.ToString() + "를 열기 시도합니다.");
            openable.Open();
        }

        public void Close(IOpenable openable)
        {
            Console.WriteLine("플레이어가 " + openable.ToString() + "를 닫기 시도합니다.");
            openable.Close();
        }
    }
}

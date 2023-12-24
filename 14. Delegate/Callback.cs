using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Delegate
{
    internal class Callback
    {
        /*******************************************************************************
         * 콜백함수
         * 
         * 델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
         * 함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback)
         *******************************************************************************/

        void Main()
        {
            File file = new File();

            Button saveButton = new Button();
            saveButton.callback = file.Save;

            Button loadButton = new Button();
            loadButton.callback = file.Load;

            saveButton.Click();     // output : 저장하기 합니다.
            loadButton.Click();     // output : 불러오기 합니다.
        }

        public class Button
        {
            public Action callback;

            public void Click()
            {
                if (callback != null)
                {
                    callback();
                }
            }
        }

        public class File
        {
            public void Save()
            {
                Console.WriteLine("저장하기 합니다.");
            }

            public void Load()
            {
                Console.WriteLine("불러오기 합니다.");
            }
        }
    }
}

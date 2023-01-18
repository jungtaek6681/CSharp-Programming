using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Event
{
    /****************************************************************
	 * 이벤트 (Event)
	 * 
	 * 이벤트 : 일련을 사건이 발생했다는 사실을 다른 개체에게 전달
	 * 딜리게이트의 일부 기능을 제한하여 이벤트의 용도로 사용
	 ****************************************************************/

    public class EventBroadCaster
    {
        // 이벤트
        public delegate void EventDelegate(string message);
        public event EventDelegate OnEvent;     // 이벤트 변수 : 딜리게이트 변수앞에 event 키워드 추가

        public void Progress(string message)
        {
            if (OnEvent != null)
            {
                OnEvent(message);               // 이벤트 발생
            }
        }
    }

    public class EventListener
    {
        public string name;

        public EventListener(string name)
        {
            this.name = name;
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine("{0}이 {1} 이벤트를 받음", name, message);
        }
    }

    internal class EventClass
    {
        public static void Test()
        {
            EventBroadCaster broadCaster = new EventBroadCaster();

            EventListener listener1 = new EventListener("리스너1");
            EventListener listener2 = new EventListener("리스너2");

            // <이벤트 제약사항 1 : = 을 통한 할당 불가>
            // 이벤트는 += 과 -= 을 통해 추가 할당과 할당 제거만이 가능
            // Why? = 을 통한 할당의 경우 이전 함수들의 할당이 사라짐
            // 객체가 이벤트에 반응할 것을 기대하고 추가하였지만 반응하지 않는 것을 방지
            broadCaster.OnEvent += listener1.ReceiveMessage;
            broadCaster.OnEvent += listener2.ReceiveMessage;
            broadCaster.OnEvent -= listener2.ReceiveMessage;
            // broadCaster.OnEvent = listener2.ReceiveMessage;	// error : = 을 통한 할당 불가

            // <이벤트 제약사항 2 : 외부에서 이벤트 발생 불가>
            // 이벤트는 이벤트가 포함된 클래스 내에서만 발생 가능
            // Why? 일련을 사건이 발생했다는 사실을 다른 개체에게 전달 용도로 사용하기 위해
            // 외부에서 이벤트를 발생시킨다면 개체가 사건이 발생하지 않은 경우에도 호출할 수 있음
            broadCaster.Progress("메세지");
            // broadCaster.OnEvent("메세지");					// error : 외부에서 이벤트 발생 불가
        }
    }
}

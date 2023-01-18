using _09._Interface.Basic;

namespace _09._Interface
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Player player = new Player();

			Door door = new Door();
			Box box = new Box();
			Dungeon dungeon = new Dungeon();
			IEnterable enterable = new Door();

			// player.Enter(box);			// error : Box 는 IEnterable 인터페이스가 없음
			player.Enter(door);
			player.Enter(dungeon);
			player.Enter(enterable);        // 인터페이스에 포함한 인스턴스도 사용가능

			// player.Exit(box);			// error : Box 는 IEnterable 인터페이스가 없음
			player.Exit(door);
			player.Exit(dungeon);

			player.Open(box);
			player.Open(door);
			// player.Open(dungeon);		// error : Dungeon 는 IOpenable 인터페이스가 없음
			// player.Open(enterable);		// error : 인스턴스가 door로 Open이 가능하더라도 IEnterable에 담았을 경우 사용 불가

			player.Close(box);
			player.Close(door);
			// player.Close(dungeon);		// error : Dungeon 는 IOpenable 인터페이스가 없음
		}
	}
}
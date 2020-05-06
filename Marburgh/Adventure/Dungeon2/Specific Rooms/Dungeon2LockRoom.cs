using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon2LockRoom:Room
{
    public Dungeon2LockRoom()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a locked door" };
        name = $"Room";
    }

    internal override void Explore()
    {
        if (GameState.Dungeon2Key)
        {
            UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
            {
                "On the door is an ornate lock",
                "",
                "You try your key in the lock",
                "",
                "Sucess! the way is open!"
            });
            Dungeon2.shell[10].West = 11;
            visited = true;
        }
        else
        {
            UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
            {
                "On the door is an ornate lock",
                "",
                "It is a solid looking door. There is no breaking it down",
                "",
                "Return when you have found the key"
            });
        }        
    }
}
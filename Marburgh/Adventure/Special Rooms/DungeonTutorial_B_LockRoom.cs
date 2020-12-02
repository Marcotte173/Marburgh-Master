using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DungeonTutorial_B_LockRoom:Room
{
    public DungeonTutorial_B_LockRoom()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a locked door" };
        name = $"Room";
    }

    internal override void Explore()
    {
        if (Create.p.Drops.Contains(AdventureItems.tutorialKey))
        {
            UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
            {
                "On the door is an ornate lock",
                "",
                "You try your key in the lock",
                "",
                "Sucess! the way is open!"
            });
            global::Explore.dungeon[10].West = 11;
            Create.p.Drops.Remove(AdventureItems.tutorialKey);
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
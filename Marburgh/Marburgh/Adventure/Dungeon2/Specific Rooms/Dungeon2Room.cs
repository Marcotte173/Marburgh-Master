using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon2Room : Room
{
    public Dungeon2Room(int size, int tier)
    : base()
    {
        this.size = size;
        this.tier = tier;
        string a = (size == 0) ? "tiny" : (size == 1) ? "small" : (size == 2) ? "medium sized" : "large";
        string b = (tier == 0) ? "squalid" : (tier == 1) ? "nondescript" : (tier == 2) ? "nice" : "splendid";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { $"You enter a {a} {b} room" };
        name = $"{a} room";
    }
    public override void Summon(int amount)
    {
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };
        for (int i = 0; i < amount; i++)
        {
            int summon = Return.RandomInt(0, 4);
            string a = (summon == 0) ? " slime" : (summon == 1) ? " kobold" : (summon == 2 )?" goblin": "n Orc";
            colourArray.Add(1);
            summonList.Add(Colour.MONSTER);
            summonList.Add("A");
            summonList.Add(a);
            summonList.Add("");
            colourArray.Add(0);
            summonList.Add("");
            if (summon == 0) global::Summon.Slime();
            else if (summon == 1) global::Summon.Kobald();
            else if (summon == 2) global::Summon.Goblin();
        }
        ActionWait(colourArray, summonList, "You have been discovered by", null);
        Location.list[10].Go();
        visited = true;
    }
}
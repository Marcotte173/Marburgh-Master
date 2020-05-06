using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Entrance:Room
{
    public Entrance(int size, int tier)
    :base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You are at the entrance to the dungeon" };
        name = $"Entrance";
        visited = true;
    }
    public override List<string> Flavor { get { return flavor; } } 
}
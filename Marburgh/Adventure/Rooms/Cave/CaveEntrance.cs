using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CaveEntrance : Room
{
    public CaveEntrance()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You are at the entrance" };
        name = $"Entrance";
    }
}

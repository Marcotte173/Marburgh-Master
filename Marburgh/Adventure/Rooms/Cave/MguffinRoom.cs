using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MguffinRoom : Room
{
    public MguffinRoom()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Mguffin" };
        name = $"Mguffin";
    }
}

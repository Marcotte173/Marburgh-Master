using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DungPile : Room
{
    public DungPile()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "Huge pile of dung!" };
        name = $"Dung Pile";
    }
}

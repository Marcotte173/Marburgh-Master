using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AncestorLetter : Room
{
    public AncestorLetter()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have and old corse" };
        name = $"Ancestor";
    }
}

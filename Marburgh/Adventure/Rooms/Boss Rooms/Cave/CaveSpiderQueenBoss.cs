using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CaveSpiderQueenBoss:Room
{
    public CaveSpiderQueenBoss()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Spider Queen" };
        name = $"Spider Queen";
    }
}
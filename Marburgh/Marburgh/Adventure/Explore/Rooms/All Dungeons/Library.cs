using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Library : Room
{
    public Library(int size, int tier)
    : base()
    {
        this.size = size;
        this.tier = tier;
        string a = (size == 0) ? "tiny" : (size == 1) ? "small" : (size == 2) ? "medium sized" : "large";
        string b = (tier == 0) ? "squalid" : (tier == 1) ? null : (tier == 2) ? "nice" : "splendid";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { $"You enter a {a}, {b} library" };
        name = $"{a} library";
    }
}
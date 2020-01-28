using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    //Variables, self explanatory
    protected int tier;
    protected int size;
    protected string name;
    protected List<int> flavorColourArray;
    protected List<string> flavor;
    protected int modifier;
    public bool visited;

    //Constructor
    public Room(int size, int tier)
    {
        this.size = size;
        this.tier = tier;
        string a = (size == 0) ? "tiny" : (size == 1) ? "small" : (size == 2) ? "medium sized" : "large";
        string b = (tier == 0) ? "squalid" : (tier == 1) ? null : (tier == 2) ? "nice" : "splendid";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { $"You enter a {a}, {b} room" };
    }

    internal void Explore()
    {
        
    }

    public int Tier { get { return tier; } set { tier = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Size { get { return size; } set { size = value; } }
    public virtual List<int> FlavorColourArray { get { return flavorColourArray; } set { flavorColourArray = value; } }
    public virtual List<string> Flavor { 
        get 
        {
            if (visited) return new List<string> { $"You have explored this room" }; 
            else return flavor; 
        } 
        set { flavor = value; } }
}
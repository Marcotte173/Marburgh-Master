using System;
using System.Collections.Generic;
using System.Text;

public class Drop
{
    //Variables, self explanatory
    public string name;
    public int amount;
    public int rare;
    public int value;
    public string description;
    public Drop(string name, int amount, int rare)
    {
        this.rare = rare;
        this.name = name;
        this.amount = amount;
    }
    public Drop(string name, int amount, int rare, string description)
    {
        this.rare = rare;
        this.name = name;
        this.amount = amount;
        this.description = description;
    }
    public Drop(string name, int amount, int rare,int value, string description)
    {
        this.rare = rare;
        this.name = name;
        this.amount = amount;
        this.value = value;
        this.description = description;
    }
    public Drop Copy()
    {
        return (Drop)MemberwiseClone();
    }
}
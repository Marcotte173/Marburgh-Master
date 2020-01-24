using System;
using System.Collections.Generic;
using System.Text;

public class Equipment
{
    protected string name;
    protected int defence;
    protected int mitigation;
    protected int price;
    protected int tier;
    protected int level;
    protected double basePrice;
    protected double coefficient;
    public Equipment() { }

    public string Name { get { return name; } set { name = value; } }
    public int Price { get { return price; } set { price = value; } }
    public int Tier { get { return tier; } set { tier = value; } }
    public int Level { get { return level; } set { level = value; } }
    public double Coefficient { get { return coefficient; } set { coefficient = value; } }
    public double BasePrice { get { return basePrice; } set { basePrice = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Mitigation { get { return mitigation; } set { mitigation = value; } }
}
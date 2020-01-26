using System;
using System.Collections.Generic;
using System.Text;

public class Location
{
    internal static Location[] list = new Location[] { new Town(), new MagicShop(), new WeaponShop(), new ArmorShop(), new  Level(), new Tavern()};
    internal static Location now = new Location();

    public Location()
    {

    }

    public void Go() { Menu(); }

    public virtual void Menu() { }
}
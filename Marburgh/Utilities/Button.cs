using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Buttons
{
    public static List<string> adventureButton = new List<string> { Color.MONSTER + "1" + Color.RESET };
    public static List<string> adventureList = new List<string> { "Orc Hideout" };
    public static List<string> shopButton = new List<string> { Color.ITEM + "M" + Color.RESET, Color.ITEM + "W" + Color.RESET, Color.ITEM + "A" + Color.RESET };
    public static List<string> shopList = new List<string> { "agic Shop", "eapon Shop", "rmor Shop" };
    public static List<string> serviceButton = new List<string> { Color.TIME + "T" + Color.RESET, Color.TIME + "L" + Color.RESET, Color.TIME + "B" + Color.RESET };
    public static List<string> serviceList = new List<string> { "avern", "evel Master","ank" };
    public static List<string> otherButton = new List<string> { Color.XP + "Y" + Color.RESET, Color.XP + "O" + Color.RESET, "","", "","?"  };
    public static List<string> otherList = new List<string> { "our House", "ther Places", "","","", Color.BLOOD + "MORE INFO" + Color.RESET };
}
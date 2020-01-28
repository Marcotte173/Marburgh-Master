using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Explore : Location
{
    protected List<Shell> shell = new List<Shell> { };
    protected Room starter;
    public static Shell currentShell;
    public Explore()
    : base()
    {
        
    }

    public override void Menu()
    {
        Console.Clear();
        for (int i = 1; i < shell.Count; i++)
        {
            if (shell[i].current) currentShell = shell[i];
        }
        UI.Keypress(currentShell.room.FlavorColourArray, currentShell.room.Flavor);
        if (currentShell.room.visited == false) currentShell.room.Explore();
        Navigate();
        Menu();
    }

    private void Navigate()
    {
        
    }

    public virtual void Summon()
    {

    }
}
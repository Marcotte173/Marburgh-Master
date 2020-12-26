using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Protect : Job
{
    public Protect(JobLocation location)
    : base(location)
    {
        this.location = location;
    }

    public override void Issue()
    {
        if (Create.p.CanExplore)
        {
            UI.Keypress(new List<int> { 1, 0, 4, 0, 3 }, new List<string>
            {
                Color.SPEAK,"","'Thank god you're here!","",
                "",
                Color.NAME,Color.SPEAK,Color.DAMAGE,Color.SPEAK,"","Fenton",""," and his gang are planning to ","","rob",""," the bank!","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","Help and I'll make it ","","worth your while","","'","",
            });
        }
        else
        {
            UI.Keypress(new List<int> { 3, 0, 1 }, new List<string>
            {
                Color.SPEAK,Color.MONSTER,Color.SPEAK,"","'Sorry, it looks like you were pretty ","","active",""," today","",
                "",
                Color.SPEAK,"","I don't think there's enough time to finish this task'",""
            });
        }
        status = JobStatus.Issued;
        ButtonCheck();
    }
    public override void Finish()
    {
        UI.Keypress(new List<int> { 0,0,2,0,1 }, new List<string>
        {
            "You wait around the bank, out of the way",
            "",
            Color.NAME,Color.DAMAGE,"Suddenly the door swings open and ","Fenton"," strides in with his ","gang"," right behind him!",
            "",
            Color.NAME,"","This is a hold up! Give me all your money!",""
        });
        Decide();        
        status = JobStatus.Complete;
    }

    private void Decide()
    {
        UI.Choice(new List<int> { 1, 0, 2, 0, 1, 0, 2 }, new List<string>
        {
            Color.NAME,"",npc.name," looks triumphantly at the thugs",
            "",
            Color.SPEAK,Color.NAME,"","You're screwed now! I found protection! Get him,","",Create.p.Name,"",
            "",
            Color.NAME,"","Fenton"," looks you over",
            "",
            Color.SPEAK,Color.GOLD,"","Tell you what, you HELP us rob this guy, we'll give you ","","20%",""
        },
        new List<string> { " Honour your commitment", " Help rob" }, new List<string> { Color.CRIT + "1" + Color.RESET, Color.DAMAGE + "2" + Color.RESET });
        string choice = Return.Option();
        if (choice == "1")
        {
            int gold = Return.RandomInt(30, 40) * Create.p.Level * (1 + Create.p.MainHand.gold);
            //SUMMON
            Combat.Menu();
            UI.Keypress(new List<int> { 1, 0, 1, 0, 1, 0, 3, 0, 2 }, new List<string>
            {
                Color.HEALTH,"You emerge ","victorious!","",
                "",
                Color.NAME,"",npc.name,"is beside him self with hapiness",
                "",
                Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                "",
                Color.GOLD,Color.HIT,"You receive ", gold.ToString() ,"and ","10"," reputation"
            });
            Create.p.Gold += gold;
            Create.p.RepAdd(10);
        }
        if (choice == "2")
        {
            int gold = Return.RandomInt(125, 180) * Create.p.Level * (1 + Create.p.MainHand.gold);
            UI.Keypress(new List<int> { 0, 0, 2, 0, 1, 0, 0, 0, 2 }, new List<string>
            {
                "You jump into the fray",
                "",
                Color.NAME,Color.DAMAGE,"Next thing you know, ",npc.name," is ","dead","",
                "",
                Color.HIT,"You run away just as people start ","investigating"," the noise",
                "",
                "You might want to lay low for a while...",
                "",
                Color.GOLD,Color.HIT,"You gain ",gold.ToString()," gold and lose ","60"," reputation"
            });
            Create.p.Gold += gold;
            Create.p.RepAdd(-60);
        }
        else Decide();
    }

    public override void ButtonCheck()
    {
        if (status == JobStatus.Available)
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.protectButton.active = false;
            Button.turnInButton.active = false;
            Button.jobButton.active = true;
        }
        else if (status == JobStatus.Issued)
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.protectButton.active = true;
            Button.turnInButton.active = false;
            Button.jobButton.active = false;
        }
        else
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.protectButton.active = false;
            Button.turnInButton.active = false;
            Button.jobButton.active = false;
        }
    }

}

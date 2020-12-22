using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Find:Job
{
    public Find(JobLocation location)
    :base(location)
    {
        this.location = location;
    }

    public override void Issue()
    {
        if (Create.p.CanExplore)
        {
            UI.Keypress(new List<int> { 3,0,3,0,3 }, new List<string>
            {
                Color.SPEAK,Color.NAME, Color.SPEAK,"","'Thank god you're here! ","","Roderick","","is missing!","",
                "",
                Color.SPEAK,Color.HEALTH, Color.SPEAK,"","He went wandering into the ","","forest",""," and he never returned!","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","I'll ","","pay","",", of course'","",
            });
            status = JobStatus.Issued;
            ButtonCheck();
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

    public override void Complete()
    {
        int gold = Return.RandomInt(15, 25) * Create.p.Level;
        UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3, 0, 3,0,2 }, new List<string>
        {
            Color.SPEAK,"","'You found him! ","",
            "",
            Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
            "",
            Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
            "",
            Color.SPEAK,Color.ITEM,Color.SPEAK,"","And ","","something",""," for your troubles'","",
            "",
            Color.GOLD,Color.HIT,Color.POTION,"You receive ", gold.ToString() ,", ","10 ","reputation and ", DropList.potionOfInvisibility.name , "",
            "",
            Color.NAME,Color.XP,"","Roderick", "is now at the ","tavern",", singing for the patrons!"

        });
        Create.p.Gold += gold;
        Create.p.RepAdd(10);
        Create.p.AddDrop(DropList.potionOfInvisibility);
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
            Button.protectButton.active = false;
            Button.turnInButton.active = false;
            Button.jobButton.active = false;
        }
        else if (status == JobStatus.Finished)
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.protectButton.active = false;
            Button.turnInButton.active = true;
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
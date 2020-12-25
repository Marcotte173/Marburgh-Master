using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum JobLocation{WeaponShop,ArmorShop,ItemShop,MagicShop,Bank}
public enum JobStatus {Available,Issued,Finished,Complete}
public class Job
{
    public JobLocation location;
    public int whichJob;
    public JobStatus status;
    public Button completeButton = new Button("", "", false);
    public NPC npc = Shop.armorNPC;
    public Job(JobLocation location) { this.location = location; }
    public Job(JobLocation location, int whichJob)
    {
        this.whichJob = whichJob;
        this.location = location;
        status = JobStatus.Available;
    }

    public virtual void Issue()
    {
        if (Create.p.CanExplore)
        {
            if (whichJob == 0)
            {
                UI.Keypress(new List<int> {1,0,2,0,3  }, new List<string>
                {
                    Color.SPEAK,"","'Now that you mention, I COULD use some help...","",
                    "",
                    Color.SPEAK,Color.DAMAGE,"","I have a lot of stuff in the back that needs to be ","","moved around","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","I'll ","","pay","",", of course'","",
                });
                completeButton = Button.InventoryButton;
            }
            else if (whichJob == 1)
            {
                UI.Keypress(new List<int> { 1, 0, 2, 0, 3 }, new List<string>
                {
                    Color.SPEAK,"","'Now that you mention, I COULD use some help...","",
                    "",
                    Color.SPEAK,Color.HIT,"","I am just overwhelmed by mail. I desperately need someone to ","","sort it","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","I'll ","","pay","",", of course'","",
                });
                completeButton = Button.SortMailButton;
            }
            else if (whichJob == 2)
            {
                UI.Keypress(new List<int> { 1, 0, 2, 0, 3 }, new List<string>
                {
                    Color.SPEAK,"","'Now that you mention, I COULD use some help...","",
                    "",
                    Color.SPEAK,Color.HEALTH,"","The side of the build desperately needs a new coat of ","","paint","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","I'll ","","pay","",", of course'","",
                });
                completeButton = Button.PaintButton;
            }
            else 
            {
                UI.Keypress(new List<int> { 1,0,1,0,3,0,3}, new List<string>
                {
                    Color.SPEAK,"","'Now that you mention, I COULD use some help...","",
                    "",
                    Color.SPEAK,"","My finances are completely of of whack, I never had the head for these things","",
                    "",
                    Color.SPEAK,Color.ENERGY,Color.SPEAK,"","If you could ","","take a look",""," at our books, I'd be super grateful","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","I'd ","","pay","",", of course'","",
                });
                completeButton = Button.BalanceBookButton;
            }            
            UI.Keypress(new List<int> {1,0,1,0,2,0,3 }, new List<string>
            {
                Color.SPEAK,"","'If you're willing to help, let me know","",
                "",
                Color.SPEAK,"","Were this a video game, you could PROBABLY get started by pressing [1]","",
                "",
                Color.SPEAK,Color.TIME,"","Just know that attempting this task will take ","","all day","",
                "",
                Color.SPEAK,Color.TIME,Color.SPEAK,"","Oh, and I need you to start ","","Today",""," or don't bother, I'll find someone else'","",
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
        
    }

    internal void ButtonsOff()
    {
        Button.InventoryButton.active = false;
        Button.SortMailButton.active = false;
        Button.PaintButton.active = false;
        Button.BalanceBookButton.active = false;
        Button.turnInButton.active = false;
        Button.jobButton.active = false;
    }

    public virtual void Finish()
    {
        int bonus = (whichJob == 0) ? Create.p.TotalStrength : (whichJob == 1) ? Create.p.TotalAgility : (whichJob == 2) ? Create.p.TotalStamina : Create.p.TotalIntelligence;
        int successCheck = Return.RandomInt(0, bonus);
        if (successCheck <=9)
        {
            int gold = Return.RandomInt(25, 35) * Create.p.Level;
            if (location == JobLocation.ArmorShop)
            {
                UI.Keypress(new List<int> { 1,0,1,0,3,0,3,}, new List<string>
                {
                    Color.HEALTH,"You do an ","amazing Job! ","",
                    "",
                    Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                    "",
                    Color.SPEAK,Color.ITEM,Color.SPEAK,"","And ","","something",""," for your troubles'","",
                });
                Return.RewardEquipment(25,35,5,Equipment.armorList,Create.p.Level);
            }
            else if (location == JobLocation.WeaponShop)
            {
                UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3 }, new List<string>
                {
                    Color.HEALTH,"You do an ","amazing Job! ","",
                    "",
                    Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                    "",
                    Color.SPEAK,Color.ITEM,Color.SPEAK,"","And ","","something",""," for your troubles'","",
                });
                Return.RewardEquipment(25, 35, 5, Equipment.LISTS[Return.RandomInt(0,4)], Create.p.Level);
            }
            else if (location == JobLocation.MagicShop)
            {
                UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3 }, new List<string>
                {
                    Color.HEALTH,"You do an ","amazing Job! ","",
                    "",
                    Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                    "",
                    Color.SPEAK,Color.ITEM,Color.SPEAK,"","And ","","something",""," for your troubles'","",
                });
                Return.RewardEquipment(25, 35, 5, Equipment.magicList, Create.p.Level);
            }
            else if (location == JobLocation.ItemShop)
            {
                if (Return.RoomForPotions())
                {
                    UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3 }, new List<string>
                    {
                        Color.HEALTH,"You do an ","amazing Job! ","",
                        "",
                        Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                        "",
                        Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                        "",
                        Color.SPEAK,Color.POTION,Color.SPEAK,"","And ","","something",""," for your troubles'","",
                    });
                    Return.RewardPotion(25, 35, 5);
                }
                else
                {
                    UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3 }, new List<string>
                    {
                        Color.HEALTH,"You do an ","amazing Job! ","",
                        "",
                        Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                        "",
                        Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                        "",
                        Color.SPEAK,Color.GOLD,Color.SPEAK,"","And ","","some more",""," for your troubles'","",
                    });
                    Return.RewardGold(25, 35, 5);
                }                
            }
            else
            {                
                UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 3}, new List<string>
                {
                    Color.HEALTH,"You do an ","amazing Job! ","",
                    "",
                    Color.SPEAK,"","'That's amazing! I'm going to tell everyone What a great job you did ","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you","",
                    "",
                    Color.SPEAK,Color.GOLD,Color.SPEAK,"","And ","","some more",""," for your troubles'","",                    
                });
                Return.RewardGold(25, 35, 5);
            }
        }
        else if (successCheck <= 5)
        {
            int gold = Return.RandomInt(25, 35) * Create.p.Level;
            UI.Keypress(new List<int> { 1,0,1,0,3,0,2 }, new List<string>
            {
                Color.HEALTH,"You do a ","good Job","",
                "",
                Color.SPEAK,"","'Good Job. I might have more work for you if this adventuring thing doesn't pan out ","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you'","",
                "",
                Color.GOLD,Color.HIT,"You receive ", gold.ToString() ,"and ","5"," reputation"
            });
            Create.p.Gold += gold;
            Create.p.RepAdd(5);
        }
        else if (successCheck <= 20)
        {
            int gold = Return.RandomInt(15, 25) * Create.p.Level;
            UI.Keypress(new List<int> { 1, 0, 1, 0, 3, 0, 1 }, new List<string>
            {
                Color.XP,"You do a ","pretty good Job","",
                "",
                Color.SPEAK,"","'Awesome. Thank for the help ","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","Here's the ","","money",""," I owe you'","",
                "",
                Color.GOLD,"You receive ", gold.ToString() ,""
            });
            Create.p.Gold += gold;
        }
        else
        {
            UI.Keypress(new List<int> { 1,0,3,0,2,0,2,0,1 }, new List<string>
            {
                Color.DAMAGE,"You do a ","terrible Job","",
                "",
                Color.SPEAK,Color.GOLD,Color.SPEAK,"","'Are you serious? You expect to be ","","paid",""," for this?","",
                "",
                Color.SPEAK,Color.DAMAGE,"","Tell, you what. If you leave right now I won't ","kick your ass","",
                "",
                Color.SPEAK,Color.CRIT,"","Trust me, the town will ","","hear about this","",
                "",
                Color.HIT,"You lose ","5","reputation",
            });
            Create.p.RepAdd(-5);
        }
        status = JobStatus.Complete;
        House.Sleep();
        House.Menu();
        ButtonCheck();
    }

    public virtual void Complete()
    {
        
    }

    public virtual void ButtonCheck()
    {
        if (status == JobStatus.Available)
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.turnInButton.active = false;
            Button.jobButton.active = true;
        }
        else if (status == JobStatus.Issued)
        {
            Button.InventoryButton.active = false;
            Button.SortMailButton.active = false;
            Button.PaintButton.active = false;
            Button.BalanceBookButton.active = false;
            Button.turnInButton.active = false;
            Button.jobButton.active = false;
            completeButton.active = true;
        }
        else ButtonsOff();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Button
{
    public string button;
    public string text;
    public bool active;

    public Button(string button, string text, bool active)
    {
        this.button = button;
        this.text = text;
        this.active = active;
    }

    //LISTS
    public static List<string> button1 = new List<string> { };
    public static List<string> list1 = new List<string> { };
    public static List<string> button2 = new List<string> { };
    public static List<string> list2 = new List<string> { };
    public static List<string> button3 = new List<string> { };
    public static List<string> list3 = new List<string> { };
    public static List<string> button4 = new List<string> { };
    public static List<string> list4 = new List<string> { };

    //NULL Button, for creating space
    public static Button nullButton = new Button("","", true);

    //DUNGEON    
    public static Button dungeon1aButton = new Button(Color.MONSTER + "1" + Color.RESET, Color.BOSS + " Orc " + Color.RESET+"Hideout", false);
    public static Button dungeon1bButton = new Button(Color.MONSTER + "2" + Color.RESET, Color.BOSS + " Savage Orc" + Color.RESET+ " lair", false);    
    public static Button dungeonForestButton = new Button(Color.MONSTER + "3" + Color.RESET, " The "+Color.HEALTH + "Forest" + Color.RESET, false);
    public static Button dungeonCaveButton = new Button(Color.MONSTER + "*" +Color.RESET," The  "+Color.MONSTER+ "Cave" + Color.RESET, false);
    public static Button dungeon2Button = new Button(Color.MONSTER + "4" + Color.RESET, " The " + Color.DEATH + "Mansion " + Color.RESET + "on the Hill", false);
    public static Button dungeon3Button = new Button(Color.MONSTER + "5" + Color.RESET, " The " + Color.MONSTER + "Castle" + Color.RESET, false);
    public static List<Button> listOfDungeons = new List<Button> { dungeon1aButton, dungeon1bButton, dungeonForestButton, dungeonCaveButton, dungeon2Button, dungeon3Button };

    //TOWN
    public static Button magicShopButton = new Button(Color.ITEM + "M" + Color.RESET, "agic Shop", false);
    public static Button weaponShopButton = new Button(Color.ITEM + "W" + Color.RESET, "eapon Shop", false);
    public static Button armorShopButton = new Button(Color.ITEM + "A" + Color.RESET, "rmor Shop", false);
    public static Button itemShopButton = new Button(Color.ITEM + "I" + Color.RESET, "tem Shop", false);
    public static List<Button> listOfShops = new List<Button> { magicShopButton, weaponShopButton, armorShopButton, itemShopButton };

    public static Button tavernButton = new Button(Color.TIME + "T" + Color.RESET, "avern", true);
    public static Button levelMasterButton = new Button(Color.TIME + "L" + Color.RESET, "evel Master", false);
    public static Button bankButton = new Button(Color.TIME + "B" + Color.RESET, "ank", false);
    public static List<Button> listOfServices = new List<Button> { tavernButton, levelMasterButton, bankButton };

    public static Button houseButton = new Button(Color.XP + "Y" + Color.RESET, "our House", true);
    public static Button graveyardButton = new Button(Color.XP + "G" + Color.RESET, "raveyard", true);
    public static Button combatArenaButton = new Button(Color.MONSTER + "C" + Color.RESET, "ombat Arena", true);
    public static List<Button> listOfOther = new List<Button> { houseButton, graveyardButton, nullButton,combatArenaButton };

    //HOUSE
    public static Button sleep = new Button(Color.NAME + "S" + Color.RESET, "leep", true);
    public static Button enhancementMachine = new Button(Color.ENHANCEMENT + "E" + Color.RESET, "nhancement Machine", false);
    public static Button hangoutButton = new Button(Color.HEALTH + "H" + Color.RESET, $"ang out with your mate", false);
    public static List<Button> listOfHouseOptions = new List<Button> { sleep, enhancementMachine,hangoutButton };

    public static Button upgradeWeapons = new Button(Color.ENHANCEMENT + "U" + Color.RESET, "pgrade", true);
    public static Button bossWeapons = new Button(Color.ENHANCEMENT + "C" + Color.RESET, "raft Weapon", false);    
    public static List<Button> listOfUpgradeOptions = new List<Button> { upgradeWeapons, bossWeapons };

    public static Button mateInfoButton = new Button(Color.MONSTER + "W" + Color.RESET, "hat should I be Doing?", true);
    public static Button drinkButton1 = new Button(Color.GOLD + "A" + Color.RESET, "sk for a drink", true);
    public static List<Button> listOfMateOptions = new List<Button> { drinkButton1, mateInfoButton };

    //BANK
    public static Button depositButton = new Button(Color.GOLD + "D" + Color.RESET, "eposit", true);
    public static Button withdrawlButton = new Button(Color.GOLD + "W" + Color.RESET, "ithdrawl", true);
    public static Button investButton = new Button(Color.GOLD + "I" + Color.RESET, "nvest", true);
    public static Button jobButton = new Button(Color.XP + "A" + Color.RESET, "sk about a job", false);
    public static Button turnInButton = new Button(Color.XP + "2" + Color.RESET, " Your task is complete", false);
    public static Button protectButton = new Button(Color.DAMAGE + "1" + Color.RESET, " Protect the Bank", false);
    public static Button BalanceBookButton = new Button(Color.ENERGY + "1" + Color.RESET, " Open The Books", false);
    public static Button InventoryButton = new Button(Color.DAMAGE + "1" + Color.RESET, " Start on inventory", false);
    public static Button PaintButton = new Button(Color.XP + "STAMINA" + Color.RESET, " Paint the building", false);
    public static Button SortMailButton = new Button(Color.XP + "CRIT" + Color.RESET, " Sort the mail", false);
    public static Button robberyButton = new Button(Color.DAMAGE + "T" + Color.RESET, "his is a robbery!", false);
    public static List<Button> listOfBankOptions = new List<Button> { depositButton, withdrawlButton, investButton, jobButton, turnInButton, SortMailButton,  PaintButton, BalanceBookButton, InventoryButton,protectButton, robberyButton };

    //SHOP
    public static Button shopBuyButton = new Button(Color.ITEM + "B" + Color.RESET, "uy", true);
    public static Button shopSellButton = new Button(Color.ITEM + "S" + Color.RESET, "ell", true);
    public static Button healthPotionBuyButton = new Button(Color.ITEM + "H" + Color.RESET, "ealth Potions", false);
    public static Button potionBuyButton = new Button(Color.ITEM + "P" + Color.RESET, "otions", false);
    public static Button thieveryButton = new Button(Color.DAMAGE + "T" + Color.RESET, "ake something when no one is looking", false);
    public static List<Button> listOfShopOptions = new List<Button> { shopBuyButton, shopSellButton, potionBuyButton, healthPotionBuyButton, jobButton, turnInButton,  SortMailButton, PaintButton, InventoryButton, BalanceBookButton, thieveryButton };

    //TAVERN
    public static Button localGossipButton = new Button(Color.XP + "L" + Color.RESET, "ocal Gossip", false);
    public static Button talkToBartenderButton = new Button(Color.XP + "T" + Color.RESET, "alk to Bartender", true);
    public static Button gambleButton = new Button(Color.GOLD + "G" + Color.RESET, "amble", false);
    public static Button townspeopleButton = new Button(Color.NAME + "S" + Color.RESET, "peak to the Towsfolk", false);
    public static List<Button> listOfTavernOptions = new List<Button> { localGossipButton, talkToBartenderButton, gambleButton, townspeopleButton};

    public static Button drinkButton = new Button(Color.GOLD + "O" + Color.RESET, "rder a drink", true);    
    public static Button chatUpBartenderButton = new Button(Color.NAME + "T" + Color.RESET, "ry to impress the Bartender", false);
    public static Button bartenderInfoButton = new Button(Color.MONSTER + "W" + Color.RESET, "hat should I be Doing?", true);
    public static List<Button> listOfBartenderOptions = new List<Button> { drinkButton, chatUpBartenderButton, bartenderInfoButton };

    public static Button startFightButton = new Button(Color.XP + "S" + Color.RESET, "tart a Bar Fight", true);
    public static Button gossipButton = new Button(Color.XP + "T" + Color.RESET, "alk to the locals", true);
    public static Button giveSpeechButton = new Button(Color.GOLD + "G" + Color.RESET, "ive a stirring speech", true);
    public static Button bardButton = new Button(Color.NAME + "L" + Color.RESET, "isten to Roderick the Bard", false);
    public static List<Button> listOfLocalsOptions = new List<Button> { gossipButton, startFightButton, giveSpeechButton, bardButton };

    public static Button beerButton = new Button(Color.XP + "B" + Color.RESET, "eer", true);
    public static Button roundButton = new Button(Color.GOLD + "R" + Color.RESET, "ound for everyone", false);
    public static Button makeDrinkButton = new Button(Color.XP + "M" + Color.RESET, "ake my own drink", true);
    public static List<Button> ListOfBuyDrinkOptions = new List<Button> { beerButton, roundButton, makeDrinkButton };

    //COMBAT ARENA
    public static Button challengeOpponentButton = new Button(Color.XP + "C" + Color.RESET, $"hallenge {CombatArena.currentGladiator.Name}", true);
    public static Button selectOpponentButton = new Button(Color.XP + "S" + Color.RESET, "elect Opponent", false);
    public static Button viewRankingsButton = new Button(Color.GOLD + "V" + Color.RESET, "iew Rankings", false);
    public static Button wagerButton = new Button(Color.NAME + "W" + Color.RESET, "ager on a match", false);
    public static Button tournamentButton = new Button(Color.NAME + "T" + Color.RESET, "ournament", false);
    public static List<Button> listOfCombatArenaOptions = new List<Button> { challengeOpponentButton, selectOpponentButton, viewRankingsButton, wagerButton,tournamentButton };

    //COMBAT
    public static Button attackButton = new Button("1", " " + Color.DAMAGE + "Attack" + Color.RESET, true);
    public static Button defenceButton = new Button("2", " " + Color.DEFENCE + "Defend" + Color.RESET, false);
    public static Button shieldButton = new Button("2", " " + Color.SHIELD + "Shield" + Color.RESET, false);
    public static Button fireBlastButton = new Button("3", " " + Color.BURNING + "FireBlast " + Color.RESET + "(" + Color.ENERGY + "2" + Color.RESET+")", false);
    public static Button rendButton = new Button("3", " " + Color.BLOOD + "Rend " + Color.RESET + "(" + Color.ENERGY + "1" + Color.RESET + ")", false);
    public static Button backstabButton = new Button("3", " " + Color.DAMAGE + "Backstab " + Color.RESET + "(" + Color.ENERGY + "1" + Color.RESET + ")", false);
    public static Button stunButton = new Button("4", " " + Color.STUNNED + "Stun " + Color.RESET + "(" + Color.ENERGY + "2" + Color.RESET + ")", false);
    public static Button magicMissileButton = new Button("4", " " + Color.ENERGY + "Magic Missile " + Color.RESET + "(" + Color.ENERGY + "3" + Color.RESET + ")", false);    
    public static Button cleaveButton = new Button("4", " " + Color.DAMAGE + "Cleave " + Color.RESET + "(" + Color.ENERGY + "2" + Color.RESET + ")", false);
    public static Button potionButton = new Button("6", " " + Color.POTION + "Potion" + Color.RESET, false);
    public static Button stunnedButton = new Button(Color.MITIGATION + "X" + Color.RESET, " " + Color.MITIGATION + "You are stunned. Press any key to continue" + Color.RESET, false);
    public static List<Button> listOfCombatOptions = new List<Button> { attackButton, defenceButton, shieldButton, fireBlastButton, backstabButton, rendButton, stunButton, magicMissileButton, cleaveButton, stunnedButton,potionButton };

    //FOREST
    public static Button deeperButton = new Button(Color.MONSTER + "G" + Color.RESET, "o deeper into the Forest", true);
    public static Button campButton = new Button(Color.HEALTH + "M" + Color.RESET,"ake Camp Here", false);
    public static List<Button> listOfForestOptions = new List<Button> { deeperButton, campButton };

    //BARTENDER
    public static Button flexButton = new Button(Color.DAMAGE + "F" + Color.RESET, "lex", true);
    public static Button sleightOfHand = new Button(Color.CRIT + "S" + Color.RESET, "leight of hand", true);
    public static Button shotsButton = new Button(Color.HEALTH + "D" + Color.RESET, "rink 8 shots", true);
    public static Button languageButton = new Button(Color.ENERGY + "R" + Color.RESET, "ecite a poem in Elven", true);
    internal static List<Button> listOfFlirtOptions = new List<Button> { flexButton, sleightOfHand, shotsButton, languageButton };

    // CRAFT
    public static Button savageDaggerButton = new Button(Color.CRIT + "1" + Color.RESET, " Savage Dagger", false);
    public static Button savageWandButton = new Button(Color.CRIT + "2" + Color.RESET, " Savage Wand", false);
    public static Button maulButton = new Button(Color.CRIT + "3" + Color.RESET, " Maul of Hope", false);
    public static Button swordButton = new Button(Color.CRIT + "4" + Color.RESET, " Sword Of Knowledge", false);
    public static Button orbButton = new Button(Color.CRIT + "5" + Color.RESET, " Orb of Zorb", false);
    public static Button cleaverButton = new Button(Color.CRIT + "6" + Color.RESET, " Haunted Cleaver", false);
    internal static List<Button> listOfCraftOptions = new List<Button> { savageDaggerButton, savageWandButton, maulButton, swordButton, orbButton , cleaverButton };
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    public int value;
    public string svalue;
    public string suit;

    public Card(string suit, string svalue, int value)
    {
        this.suit = suit;
        this.svalue = svalue;
        this.value = value;
    }
}

public class BlackJackGame
{
    public static Random rand = new Random();
    public static List<string> displayText = new List<string> { "" };
    public static List<int> displayColourArray = new List<int> { 0 };
    public static List<Card> playerHand = new List<Card> { new Card("Spades", "Ace", 11) };
    public static List<Card> dealerHand = new List<Card> { new Card("Spades", "Ace", 11) };
    public static List<Card> deck = new List<Card> { new Card("Spades", "Ace", 11) };
    public static string[] suits = new string[] { "Spades", "Clubs", "Diamonds", "Hearts" };
    public static string[] svalues = new string[] { " Ace", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine", " Ten", " Jack", " Queen", " King" };
    public static int[] values = new int[] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

    public static void StartBlackJack(Creature p, int wager)
    {
        SetUp();
        while (playerHand.Count < 2)
        {
            Deal(playerHand);
        }
        while (dealerHand.Count < 2)
        {
            Deal(dealerHand);
        }
        PlayBlackJack(p, wager);
    }

    public static void PlayBlackJack(Creature p, int wager)
    {
        Console.Clear();
        DisplayTextCreate();
        if (playerHand.Count < 2 && Count(playerHand) == 21)
        {
            displayColourArray.Add(0);
            displayText.Add("Blackjack! That pays 3 to 1!");
            UI.Keypress(displayColourArray, displayText);
            Win(p, wager, 3);
            Tavern.Menu();
        }
        if (Count(playerHand) > 21)
        {
            UI.Keypress(displayColourArray, displayText);
            Lose();
            Tavern.Menu();
        }
        displayColourArray.Add(2);
        string dhColour = Color.MONSTER;
        if (dealerHand[0].suit == "Spades" || dealerHand[0].suit == "Clubs") dhColour = Color.SHIELD;
        displayText.Add(Color.NAME);
        displayText.Add(dhColour);
        displayText.Add("The dealer is showing a");
        displayText.Add($"{dealerHand[0].svalue} ");
        displayText.Add("of ");
        displayText.Add($"{dealerHand[0].suit}");
        displayText.Add("");
        UI.Choice(displayColourArray, displayText,
            new List<string> { "it", "tay" }, new List<string> { Color.ITEM + "H" + Color.RESET, Color.ITEM + "S" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "h")
        {
            Deal(playerHand);
            PlayBlackJack(p, wager);
        }
        else if (choice == "s") Resolve(p, playerHand, dealerHand, wager);
        else PlayBlackJack(p, wager);
    }

    private static void DisplayTextCreate()
    {
        displayText.Clear();
        displayColourArray.Clear();
        for (int i = 0; i < playerHand.Count; i++)
        {
            displayColourArray.Add(2);
            string pHColour = Color.MONSTER;
            if (playerHand[i].suit == "Spades" || playerHand[i].suit == "Clubs") pHColour = Color.SHIELD;
            displayText.Add(Color.NAME);
            displayText.Add(pHColour);
            if (playerHand[i].svalue == " Ace" || playerHand[i].svalue == " Eight") displayText.Add("You have an");
            else displayText.Add("You have a");
            displayText.Add($"{playerHand[i].svalue} ");
            displayText.Add("of ");
            displayText.Add($"{playerHand[i].suit}");
            displayText.Add("");
        }
        displayColourArray.Add(0);
        displayText.Add("");
        displayColourArray.Add(1);
        displayText.Add(Color.NAME);
        displayText.Add("That makes ");
        displayText.Add($"{Count(playerHand)}");
        displayText.Add("");
        displayColourArray.Add(0);
        displayText.Add("");
    }

    private static void SetUp()
    {
        deck.Clear();
        for (int i = 0; i < suits.Length; i++)
        {
            for (int x = 0; x < svalues.Length; x++)
            {
                deck.Add(new Card(suits[i], svalues[x], values[x]));
            }
        }
        playerHand.Clear();
        dealerHand.Clear();
    }

    private static void Win(Creature p, int wager, int multiplier)
    {
        p.Gold += wager * multiplier;
        UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
            {
                "You win!",
                "",
                Color.GOLD, "You receive ",$"{wager * multiplier}"," gold!"
            });
    }

    private static void Resolve(Creature p, List<Card> playerHand, List<Card> dealerHand, int wager)
    {
        DisplayTextCreate();
        displayColourArray.Add(4);
        string dhColour1 = Color.MONSTER;
        if (dealerHand[0].suit == "Spades" || dealerHand[0].suit == "Clubs") dhColour1 = Color.SHIELD;
        string dhColour2 = Color.MONSTER;
        if (dealerHand[0].suit == "Spades" || dealerHand[0].suit == "Clubs") dhColour2 = Color.SHIELD;
        displayText.Add(Color.NAME);
        displayText.Add(dhColour1);
        displayText.Add(Color.NAME);
        displayText.Add(dhColour2);
        if (dealerHand[0].svalue == " Ace" || dealerHand[0].svalue == " Eight") displayText.Add("The dealer flips his cards, revealing an");
        else displayText.Add("The dealer flips his cards, revealing a");
        displayText.Add($"{dealerHand[0].svalue} ");
        displayText.Add("of ");
        displayText.Add($"{dealerHand[0].suit} ");
        if (dealerHand[1].svalue == " Ace" || dealerHand[1].svalue == " Eight") displayText.Add("and an");
        else displayText.Add("and a");
        displayText.Add($"{dealerHand[1].svalue} ");
        displayText.Add("of ");
        displayText.Add($"{dealerHand[1].suit}");
        displayText.Add("");
        displayColourArray.Add(0);
        displayText.Add("");
        while (Count(dealerHand) < 17)
        {
            Deal(dealerHand);
            displayColourArray.Add(2);
            string dhColour = Color.MONSTER;
            if (dealerHand[0].suit == "Spades" || dealerHand[0].suit == "Clubs") dhColour = Color.SHIELD;
            displayText.Add(Color.NAME);
            displayText.Add(dhColour);
            if (dealerHand[dealerHand.Count - 1].svalue == " Ace" || dealerHand[dealerHand.Count - 1].svalue == " Eight") displayText.Add("The dealer draws an");
            else displayText.Add("The dealer draws a");
            displayText.Add($"{dealerHand[dealerHand.Count - 1].svalue} ");
            displayText.Add("of ");
            displayText.Add($"{dealerHand[dealerHand.Count - 1].suit}");
            displayText.Add("");
        }
        displayColourArray.Add(0);
        displayText.Add("");
        if (Count(dealerHand) > 21)
        {
            displayColourArray.Add(0);
            displayText.Add("The dealer busts!");
            UI.Keypress(displayColourArray, displayText);
            Win(p, wager, 2);
        }
        else
        {
            displayColourArray.Add(1);
            displayText.Add(Color.NAME);
            displayText.Add("Your total is ");
            displayText.Add($"{Count(playerHand)}");
            displayText.Add("");
            displayColourArray.Add(1);
            displayText.Add(Color.NAME);
            displayText.Add("The Dealer's total is ");
            displayText.Add($"{Count(dealerHand)}");
            displayText.Add("");
            UI.Keypress(displayColourArray, displayText);
            if (Count(dealerHand) > Count(playerHand)) Lose();
            else if (Count(dealerHand) < Count(playerHand)) Win(p, wager, 2);
            else
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    "You break even!",
                    "",
                    "You get your money back!"
                });
                p.Gold += wager;
            }
        }
    }

    private static void Lose()
    {
        UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
            {
                "You Lose!",
                "",
                "With a grin, the dealer takes your money"
            });
    }

    private static void Deal(List<Card> hand)
    {
        int cardDraw = rand.Next(0, deck.Count - 1);
        hand.Add(deck[cardDraw]);
        deck.RemoveAt(cardDraw);
    }

    public static int Count(List<Card> hand)
    {
        int aces = 0;
        int val = 0;
        for (int i = 0; i < hand.Count; i++)
        {
            val += hand[i].value;
        }
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].value == 11) aces++;
        }
        while (val > 21 && aces > 0)
        {
            aces--;
            val -= 10;
        }
        return val;
    }
}
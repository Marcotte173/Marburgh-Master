using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FavoredTrait {Strength, Agility, Stamina, Intelligence };

public class NPC
{
    public string name;
    public string race;
    public string pronoun1a;
    public string pronoun1b;
    public string pronoun1c;
    public string pronoun1d;
    public string pronoun2a;
    public string pronoun2b;
    public string pronoun3;
    public int friendlyness;
    public int preferredRep;
    public string job;
    public FavoredTrait favored;
    public NPC(string job)
    {
        this.job = job;
        int nameNumber = Return.RandomInt(0, Name.fanatsyList.Count);
        name = Name.fanatsyList[nameNumber];
        Name.fanatsyList.RemoveAt(nameNumber);
        race = Name.raceList[Return.RandomInt(0, Name.raceList.Count)];
        int pronoun = Return.RandomInt(0, 3);
        pronoun1a = (pronoun == 1) ? "He" : (pronoun == 2) ? "She" : "They";
        pronoun1b = (pronoun == 1) ? "he" : (pronoun == 2) ? "she" : "they";
        pronoun1c = (pronoun == 1) ? "he is" : (pronoun == 2) ? "she is" : "they are";
        pronoun1d = (pronoun == 1) ?  "he sees" : (pronoun == 2) ? "she sees" : "they see";
        pronoun2a = (pronoun == 1) ? "Him" : (pronoun == 2) ? "Her" : "Them";
        pronoun2b = (pronoun == 1) ? "him" : (pronoun == 2) ? "her" : "them";
        pronoun3 = (pronoun == 1) ? "his" : (pronoun == 2) ? "her" : "their";
        friendlyness = 2;        
    }
}
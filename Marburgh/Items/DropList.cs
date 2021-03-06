﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DropList
{
    public static Drop tutorialKey = new Drop("Iron Key", 1, 3);
    public static Drop monsterTooth = new Drop("Monster Tooth", 1, 0);
    public static Drop monsterEye = new Drop("Monster Eye", 1, 0);
    public static Drop savageOrcFang = new Drop("Savage Orc Fang", 1, 1);
    public static Drop necromancerBrain = new Drop("Necromancer Brain", 1, 1);
    public static Drop slime = new Drop("Slime", 1, 1);
    public static Drop potionOfDeath = new Drop("Potion Of Death",1,2);
    public static Drop potionOfFire        = new Drop("Potion Of Fire", 1, 2,300, "Sets an "+Color.MONSTER + "opponent" + Color.RESET + " on " + Color.BURNING + "fire" + Color.RESET + ". " + Color.POTION + "Single Use" + Color.RESET);
    public static Drop potionOfLearning    = new Drop("Potion Of Learning", 1, 2,250, "+1 " + Color.ENERGY + "Intelligence" + Color.RESET + ". " + Color.POTION + "Wears off overnight" + Color.RESET);
    public static Drop potionOfLife        = new Drop("Potion Of Life", 1, 2,500, "+1 " + Color.HEALTH + "Stamina" + Color.RESET + ". " + Color.POTION + "Wears off overnight" + Color.RESET);
    public static Drop potionOfPower       = new Drop("Potion Of Power", 1, 2, 500, "+1 " + Color.DAMAGE + "Strength" + Color.RESET + "." + Color.POTION + " Wears off overnight" + Color.RESET);
    public static Drop potionOfProwess     = new Drop("Potion Of Prowess", 1, 2, 500, "+1" + Color.HIT + " Agility" + Color.RESET + ". " + Color.POTION + "Wears off overnight" + Color.RESET);
    public static Drop potionOfKnowledge   = new Drop("Potion Of Knowledge", 1, 2, 500, "+25% " + Color.XP + "xp" + Color.RESET + " from combat. " + Color.POTION + "Wears off overnight" + Color.RESET);
    public static Drop potionOfInvisibility = new Drop("Potion Of Invisibility", 1, 2, 500, "Makes the user " + Color.ENERGY + "invisible"+ Color.RESET);
    public static Drop purePotionOfLife = new Drop("Pure potion Of Life", 1, 2);
    public static Drop purePotionOfPower = new Drop("Pure potion Of Power", 1, 2);
    public static Drop purePotionOfProwess = new Drop("Pure potion Of Prowess", 1, 2);
    public static Drop purePotionOfKnowledge = new Drop("Pure potion Of Knowledge", 1, 2);
    public static Drop mansionMedalion = new Drop("Necromancer's Medallion", 1, 3);
    public static Drop brokenCleaver = new Drop("Broken Cleaver", 1, 1);
    public static Drop spiderEgg = new Drop("Spider Egg", 1, 1);
    public static Drop batBrain = new Drop("Bat Brain", 1, 1);
    public static Drop bone = new Drop("Old Bone", 1, 1);
    public static Drop ghoulFang = new Drop("Ghoul Fang", 1, 1);
    public static Drop bearPaw = new Drop("Bear Paw", 1, 1);
    public static Drop mguffin = new Drop("Mguffin", 1, 1);
}                 
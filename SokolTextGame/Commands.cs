﻿using SokolTextGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SokolTextGame
{
    public interface ICommand
    {
        public void Execute(string[] words, World world);
    }
    public class Echo : ICommand
    {
        public void Execute(string[] words, World world)
        {
            string text = string.Join(" ", words.Skip(1));
            Console.WriteLine(text);
        }
    }

    public class Exit : ICommand
    {
        public void Execute(string[] words, World world)
        {
            Console.WriteLine("See you later..");
            Environment.Exit(0);
        }
    }
    public class WhoAmI : ICommand
    {
        public void Execute(string[] words, World world)
        {
            if (words.Length == 1 && string.Join(" ", words) == "who") Console.Write("who, who? =)\n");
            else if (words.Length == 3 && string.Join(" ", words) == "who am i") Console.Write( world?.player?.Description);
            else Console.Write("I know the command \"who am i\"\n");
        }
    }
    public class Look : ICommand
    {
        public void Execute(string[] words, World world)
        {
            if (words.Length == 1 && string.Join(" ", words) == "look") Console.Write("Look... What's next? You can look at your weapon\n");
            else if (words.Length == 4 && string.Join(" ", words) == "look at my weapon") Console.Write(world?.player?.Weapon.Descriprion);
            else Console.Write("I know the command \"look at my weapon\"\n");
        }
    }

    public class Unknown : ICommand
    {
        public void Execute(string[] words, World world)
        {
            Console.WriteLine("I'm sorry, but there is no such command. =) ");
        }
    }

    public class CreatePlayer : ICommand
    {
        public void Execute(string[] words, World world)
        {
            if (words[0].Equals("warrior")) world.player = new Warrior(new BareFists());
            else if (words[0].Equals("rogue")) world.player = new Rogue(new BareFists());
            else if (words[0].Equals("wizard")) world.player = new Wizard(new BareFists());            
        }
    }
}
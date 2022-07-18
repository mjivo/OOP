using System;
using System.Linq;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            //test is and as
            //test to all
            List<BaseHero> heroes = new List<BaseHero>();
            int N = int.Parse(Console.ReadLine());
            while (N > heroes.Count)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero hero = null;
                switch (heroType.ToLower())
                {
                    case "druid":
                        hero = new Druid(name);
                        break;
                    case "paladin":
                        hero = new Paladin(name);
                        break;
                    case "rogue":
                        hero = new Rogue(name);
                        break;
                    case "warrior":
                        hero = new Warrior(name);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }
                heroes.Add(hero);
            }
            int bossPower = int.Parse(Console.ReadLine());
            //for (int i = 0; i < heroes.Count; i++)
            //{
            //    var hero = heroes[i];
            //    if (heroes[i] is Warrior)
            //    {
            //        Warrior warrior = heroes[i] as Warrior;
            //    }
            //}
            //heroes.ForEach(h => Console.WriteLine((h as Warrior).CastAbility()));
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int heroesPower = heroes.Sum(h => h.Power);
            Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
            //if (heroesPower < bossPower)
            //{
            //    Console.WriteLine("Defeat...");
            //}
            //else
            //{
            //    Console.WriteLine("Victory!");
            //}
        }
    }
}

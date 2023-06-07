using System;
using System.Collections.Generic;
namespace HeistII_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> Rolodex = new List<IRobber>();
            Hacker hacker1 = new Hacker()
            {
                Name = "thaker",
                SkillLevel = 55,
                PercentageCut = 70,
            };
            Hacker hacker2 = new Hacker()
            {
                Name = "slaker",
                SkillLevel = 20,
                PercentageCut = 15,
            };
            Muscle muscle1 = new Muscle()
            {
                Name = "vin diesel",
                SkillLevel = 90,
                PercentageCut = 77,
            };
            Muscle muscle2 = new Muscle()
            {
                Name = "D-wayne The ROCK",
                SkillLevel = 40,
                PercentageCut = 45,
            };
            LockSpecialist lock1 = new LockSpecialist()
            {
                Name = "Robert pinn",
                SkillLevel = 22,
                PercentageCut = 27,
            };
            LockSpecialist lock2 = new LockSpecialist()
            {
                Name = "Azzina",
                SkillLevel = 68,
                PercentageCut = 39,
            };
            Rolodex.Add(hacker1);
            Rolodex.Add(hacker2);
            Rolodex.Add(muscle1);
            Rolodex.Add(muscle2);
            Rolodex.Add(lock1);
            Rolodex.Add(lock2);
        }
    }
}

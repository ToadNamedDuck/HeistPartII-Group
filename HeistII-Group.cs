using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("Welcome to Heist: Part II - Group Edition");
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"There are currently {Rolodex.Count} robbers in your rolodex.");
            Console.WriteLine("Would you like to add to your rolodex today? Y/N");
            string answer = Console.ReadLine();
            bool robberLoop = true;
            if (answer.ToLower() == "y")
            {
                while (robberLoop)
                {
                    Console.WriteLine("___________________________________");
                    Console.WriteLine("What is your contact's name?");
                    string _newContactName = Console.ReadLine();
                    if (_newContactName == "")
                    {
                        robberLoop = false;
                        break;
                    }
                    Console.WriteLine(@"What is your contact's specialty?
                1: Hacker (Disables Alarm)
                2: Muscle (Disables Guards)
                3: Lock Specialist (Cracks the Vault)");
                    string _newContactSpecialty = Console.ReadLine();

                    if (_newContactSpecialty == "1")
                    {
                        Hacker newContact = new Hacker();
                        Rolodex.Add(newContact);
                    }
                    else if (_newContactSpecialty == "2")
                    {
                        Muscle newContact = new Muscle();
                        Rolodex.Add(newContact);
                    }
                    else if (_newContactSpecialty == "3")
                    {
                        LockSpecialist newcontact = new LockSpecialist();
                        Rolodex.Add(newcontact);
                    }
                    else
                    {
                        Console.WriteLine("You seem like the Muscle type...");
                        Muscle newContact = new Muscle();
                        Rolodex.Add(newContact);
                    }

                    Console.WriteLine("What is your contact's skill level?");
                    string _newContactSkillLevel = Console.ReadLine();
                    Console.WriteLine("What is the percentage cut your contact expects to take from the heist?");
                    string _newContactCut = Console.ReadLine();

                    Rolodex.Select(i => i).TakeLast(1).Single().Name = _newContactName;
                    Rolodex.Select(i => i).TakeLast(1).Single().SkillLevel = int.Parse(_newContactSkillLevel);
                    Rolodex.Select(i => i).TakeLast(1).Single().PercentageCut = int.Parse(_newContactCut);

                    Console.WriteLine("______________________________________________");
                    Console.WriteLine("Your new contact has been added!");
                }
            }

            Bank thebank = new Bank();

            Random random = new Random();
            thebank.AlarmScore = random.Next(0, 101);
            thebank.VaultScore = random.Next(0, 101);
            thebank.SecurityGuardScore = random.Next(0, 101);
            thebank.CashOnHand = random.Next(50000, 1000001);

            Console.WriteLine("______________________________________________");
            Console.WriteLine("Recon Report of The Banks");
            if (thebank.AlarmScore > thebank.VaultScore && thebank.AlarmScore > thebank.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure:  The Alarms.");
            }
            else if (thebank.VaultScore > thebank.AlarmScore && thebank.VaultScore > thebank.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: The Vault.");
            }
            else if (thebank.SecurityGuardScore > thebank.AlarmScore && thebank.VaultScore < thebank.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: The super buff Guards.");
            }
            else
            {
                Console.WriteLine("Everything is secure.");
            }

            if (thebank.AlarmScore < thebank.VaultScore && thebank.AlarmScore < thebank.SecurityGuardScore)
            {
                Console.WriteLine("Least Secure: The Alarms.");
            }
            else if (thebank.VaultScore < thebank.AlarmScore && thebank.VaultScore < thebank.SecurityGuardScore)
            {
                Console.WriteLine("Least Secure: The Vault.");
            }
            else if (thebank.SecurityGuardScore < thebank.AlarmScore && thebank.VaultScore > thebank.SecurityGuardScore)
            {
                Console.WriteLine("Least Secure: The super weak Guards.");
            }
            Console.WriteLine("-----------------------------------------");

            List<IRobber> Crew = new List<IRobber>();

            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Type the number of the contact that you want in your crew");


                for (int i = 0; i < Rolodex.Count; i++)
                {
                    int _totalCutGiven = 0;
                    foreach (IRobber r in Crew)
                    {
                        _totalCutGiven += r.PercentageCut;
                    }
                    if ((_totalCutGiven + Rolodex[i].PercentageCut) <= 100)
                    {
                        Console.WriteLine($"Crewmember{i + 1}: Name: {Rolodex[i].Name}, Skill Level: {Rolodex[i].SkillLevel}, Percentage Cut: {Rolodex[i].PercentageCut}");
                    }
                }

                try
                {
                    int crewAnswer = int.Parse(Console.ReadLine());
                    Crew.Add(Rolodex[crewAnswer - 1]);
                    Rolodex.Remove(Rolodex[crewAnswer - 1]);
                }
                catch (System.FormatException)
                {
                    break;
                }
            }
            //Begin the heist
            Console.WriteLine("Please hold while we rob a bank...");
            foreach (IRobber crewMember in Crew)
            {
                crewMember.PerformSkill(thebank);
            }
            if ((thebank.AlarmScore + thebank.SecurityGuardScore + thebank.VaultScore) <= 0)
            {
                Console.WriteLine("The heist was a success!");
                int overallTaken = 0;
                foreach (IRobber crewMember in Crew)
                {
                    Console.WriteLine($"{crewMember.Name} takes {(crewMember.PercentageCut) * (thebank.CashOnHand / 100)} of the cash.");
                    overallTaken = overallTaken + ((crewMember.PercentageCut) * (thebank.CashOnHand / 100));

                }
                Console.WriteLine($"And you get ${thebank.CashOnHand - overallTaken}");
            }
            else
            {
                Console.WriteLine("Y'all are failures! Go straight to Jail!");
            }
        }
    }
}

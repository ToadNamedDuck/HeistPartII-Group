using System;

namespace HeistII_Group
{

  public class Hacker : IRobber
  {

    public string Name { get; set; }

    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public void PerformSkill(Bank bank)
    {
      bank.AlarmScore = bank.AlarmScore - SkillLevel;
      Console.WriteLine($"{Name} is hacking the mainframe... The alarm score has been decreased by {SkillLevel} points");
      if (bank.AlarmScore <= 0)
      {
        Console.WriteLine($"{Name} says: We've hacked our way into RICHES!!!!");
      }
    }

  }
}
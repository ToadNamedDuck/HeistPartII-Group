using System;

namespace HeistII_Group
{

  public class Muscle : IRobber
  {

    public string Name { get; set; }

    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public void PerformSkill(Bank bank)
    {
      bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
      Console.WriteLine($"{Name} is fighting off security. Decreased security by {SkillLevel} points");
      if (bank.SecurityGuardScore <= 0)
      {
        Console.WriteLine($"{Name} muscles the security down!!");
      }
    }


  }
}
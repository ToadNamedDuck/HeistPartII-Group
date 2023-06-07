using System;

namespace HeistII_Group
{

  public class LockSpecialist : IRobber
  {

    public string Name { get; set; }

    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public void PerformSkill(Bank bank)
    {
      bank.VaultScore = bank.VaultScore - SkillLevel;
      Console.WriteLine($"Lock specialist, {Name} is taking out his bobby pins and picking the lock...the vault's security has decreased by {SkillLevel} points");
      if (bank.VaultScore <= 0)
      {
        Console.WriteLine($"{Name} has successfully picked the locks! We're in!!");
      }
    }
  }
}
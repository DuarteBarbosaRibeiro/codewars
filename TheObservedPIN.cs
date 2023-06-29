// URL: https://www.codewars.com/kata/5263c6999e0f40dee200059d

using System.Collections.Generic;
using System.Linq;

public class Kata
{
  static Dictionary<char, string> PossibleDigits = new() {
    { '0', "08" },
    { '1', "124" },
    { '2', "1235" },
    { '3', "236" },
    { '4', "1457" },
    { '5', "24568" },
    { '6', "3569" },
    { '7', "478" },
    { '8', "05789" },
    { '9', "689" }
  };
  
  static IEnumerable<string> GetPINsRecursion(int index, string observed, string pin) {
    if (index == observed.Length) {
      yield return pin;
      yield break;
    }
    foreach (char digit in PossibleDigits[observed[index]])
      foreach (string result in GetPINsRecursion(index + 1, observed, pin + digit))
        yield return result;
  }
  
  public static List<string> GetPINs(string observed)
  {
    return GetPINsRecursion(0, observed, "").ToList();
  }
}
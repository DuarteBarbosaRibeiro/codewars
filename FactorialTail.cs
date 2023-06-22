// URL: https://www.codewars.com/kata/55c4eb777e07c13528000021

using System.Collections.Generic;

public class FactorialTail
{
  public static int zeroes(int radix, int number)
  {
    Dictionary<int, int> radix_factors = new();
    Dictionary<int, int> number_factors = new();
    
    int factor = 2;
    while (radix != 1) {
      if (radix % factor == 0) {
        radix_factors.TryAdd(factor, 0);
        radix_factors[factor]++;
        number_factors.TryAdd(factor, 0);
        radix /= factor;
        continue;
      }
      factor++;
    }
    
    for (int a = 2; a <= number; a++) {
      int a_cp = a;
      foreach (int b in radix_factors.Keys) {
        while (a_cp != 1 && a_cp % b == 0) {
          number_factors[b]++;
          a_cp /= b;
        }
      }
    }
    
    int result = int.MaxValue;
    
    foreach (KeyValuePair<int, int> kvp in number_factors) {
      int temp = kvp.Value / radix_factors[kvp.Key];
      result = temp < result ? temp : result;
    }
    
    return result;
  }
}
// URL: https://www.codewars.com/kata/5254ca2719453dcc0b00027d

using System.Collections.Generic;

class Permutations
{
  /*
    remaining: Which numbers haven't been consumed yet in the branch of the recursion.
    sequence:  The current sequence of the permutation.
    index:     Index in sequence where the next number should be added.
  */
  static IEnumerable<int[]> GetPermutationsRecursion(bool[] remaining, int[] sequence, int index) {
    // index == remaining.Length => Permutation is completed.
    if (index == remaining.Length)
      yield return sequence;
    
    // Arrays are passed by reference, but the current
    // array cannot be modified by the next branches,
    // so a copy is created.
    bool[] remaining_copy;
    
    // For each remaining number, do all the permutations
    // where sequence[index] is said number.
    for (int i = 0; i < remaining.Length; i++) {
      if (remaining[i]) {
        remaining_copy = new bool[remaining.Length];
        Array.Copy(remaining, remaining_copy, remaining.Length);
        remaining_copy[i] = false;
        sequence[index] = i;
        foreach (int[] result in GetPermutationsRecursion(remaining_copy, sequence, index + 1))
          yield return result;
      }
    }
  }
  
  // Sets up data for the recursive functions
  static IEnumerable<int[]> GetPermutations(int n) {
    bool[] remaining = new bool[n];
    int[] sequence = new int[n];
    for (int i = 0; i < n; i++)
      remaining[i] = true;
    foreach (int[] permutation in GetPermutationsRecursion(remaining, sequence, 0))
      yield return permutation;
  }
  
  public static List<string> SinglePermutations(string s)
  {    
    List<string> result = new();
    IEnumerable<int[]> permutations = GetPermutations(s.Length);
    foreach (int[] permutation in permutations) {
      string str = "";
      foreach (int index in permutation)
        str += s[index];
      // Since every permutation is explored
      // there may be duplicates if there
      // are repeating characters in s.
      if (!result.Contains(str))
        result.Add(str);
    }
    return result;
  }
}
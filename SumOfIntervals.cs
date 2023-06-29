// URL: https://www.codewars.com/kata/52b7ed099cdc285c300001cd

using System.Collections.Generic;
using System.Linq;

public class Intervals
{
  /* 
    Approach: intervals are sorted by their lowerbound
    then built left to right.
    
    Example: { [1, 5], [7, 9], ... }
    Since [7, 9] doesn't overlap [1, 5], no
    interval after will overlap it, since
    they all start at at least 7.
  */
  public static int SumIntervals((int, int)[] intervals)
  {
    // Edge case
    if (intervals.Length == 0)
      return 0;
    
    // Order intervals by starting number
    List<(int, int)> intervals_sorted = intervals.OrderBy(r => r.Item1).ToList();
    
    int result = 0;
    int start = intervals_sorted[0].Item1;
    int end = intervals_sorted[0].Item2;
    
    for (int i = 1; i < intervals_sorted.Count; i++) {
      // Overlapping interval found
      if (intervals_sorted[i].Item1 < end) {
        // Maximize end
        if (intervals_sorted[i].Item2 > end)
          end = intervals_sorted[i].Item2;
        continue;
      }
      // Not overlapping interval, addup previous
      // and update start and end to new interval
      result += end - start;
      start = intervals_sorted[i].Item1;
      end = intervals_sorted[i].Item2;
    }
    // Add up final interval
    result += end - start;
    return result;
  }
}
// URL: https://www.codewars.com/kata/5324945e2ece5e1f32000370

public static class Kata
{
  public static string sumStrings(string a, string b)
  {
    string result = "";
    int pos = 1;
    int remainder = 0;
    while (pos <= a.Length || pos <= b.Length || remainder != 0) {
      int a_digit = pos <= a.Length ? a[a.Length - pos] - '0' : 0;
      int b_digit = pos <= b.Length ? b[b.Length - pos] - '0' : 0;
      int sum = a_digit + b_digit + remainder;
      remainder = sum / 10;
      result = (sum % 10).ToString() + result;
      pos++;
    }
    
    // Remove trailing zeroes
    pos = 0;
    while (pos < result.Length - 1 && result[pos] == '0')
      pos++;
    return result.Substring(pos);
  }
}
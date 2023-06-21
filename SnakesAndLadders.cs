using System.Collections.Generic;

namespace CodeWars
{
    class SnakesLadders
    {
      const int NUMBER_OF_PLAYERS = 2;
      const int END_TILE = 100;
      
      // Snakes and Ladders behave the same:
      // If you land at the start of one,
      // move to its end, so they are mapped
      // in the same dictionary
      Dictionary<int, int> Paths = new() {
        // Ladders
        { 2, 38 },
        { 7, 14 },
        { 8, 31 },
        { 15, 26 },
        { 21, 42 },
        { 28, 84 },
        { 36, 44 },
        { 51, 67 },
        { 71, 91 },
        { 78, 98 },
        { 87, 94 },
        
        // Snakes
        { 16, 6 },
        { 46, 25 },
        { 49, 11 },
        { 62, 19 },
        { 64, 60 },
        { 74, 53 },
        { 89, 68 },
        { 92, 88 },
        { 95, 75 },
        { 99, 80 }
      };
      
      int[] Players = new int[NUMBER_OF_PLAYERS];
      int CurrentPlayer = 0;
      bool GameOver = false;
      
      public SnakesLadders() {
        for (int i = 0; i < Players.Length; i++)
          Players[i] = 0;
      }
      
      public string play (int die1, int die2)
      {
        if (GameOver)
          return "Game over!";
        
        Players[CurrentPlayer] += die1 + die2;
        if (Players[CurrentPlayer] == END_TILE) {
          GameOver = true;
          return string.Format("Player {0} Wins!", CurrentPlayer + 1);
        }
        
        // Calculate "bounce" off
        if (Players[CurrentPlayer] > END_TILE)
          Players[CurrentPlayer] = (2 * END_TILE) - Players[CurrentPlayer];
        
        // Check for Snake or Ladder
        if (Paths.ContainsKey(Players[CurrentPlayer]))
          Players[CurrentPlayer] = Paths[Players[CurrentPlayer]];
        
        string result = string.Format("Player {0} is on square {1}", CurrentPlayer + 1, Players[CurrentPlayer]);
        
        if (die1 != die2)
          CurrentPlayer = (CurrentPlayer + 1) % NUMBER_OF_PLAYERS;
        
        return result;
      }
    }
}
// Brute force version of Tic Tac Toe.
//
using System;

public class TicTacToe
{

  static void DrawHorizontal()
  {
    System.Console.WriteLine("--------------");
  }

  static char[] LoadGrid(char[] grid)
  {
    for (int i = 1; i<10; i++)
    {
      grid[i] = (char)(i+48);
    }
    return grid;
  }

  static void DrawGrid(char[] grid)
  {
    System.Console.WriteLine("\n {0} | {1} | {2} ", grid[1], grid[2], grid[3]);
    DrawHorizontal();
    System.Console.WriteLine(" {0} | {1} | {2} ", grid[4], grid[5], grid[6]);
    DrawHorizontal();
    System.Console.WriteLine(" {0} | {1} | {2} ", grid[7], grid[8], grid[9]);
  }

  static void DrawColorGrid(char[] grid)
  {
    System.Console.WriteLine("\n");

    for (int i = 1; i<10; i++)
    {
      if (grid[i].Equals('X'))
      {
        Console.ForegroundColor = ConsoleColor.Red;
      }
      else if (grid[i].Equals('O'))
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.White;
      }

      System.Console.Write(" {0} ", grid[i]);

      if (i % 3 != 0)
      {
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.Write("|");
      }

      if (i % 3 == 0 && i % 9 != 0)
      {
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("\n-----------");
      }
    }
  }

  static char[] UpdateGrid(int move, char player, char[] grid)
  {

    grid[move] = player;

    return grid;
  }

  static bool CheckWinner(char[] grid)
  {
    bool winner = false;

    // check horizontal
    if (grid[1] == grid[2] && grid[2] == grid[3]) winner = true;
    if (grid[4] == grid[5] && grid[5] == grid[6]) winner = true;
    if (grid[7] == grid[8] && grid[8] == grid[9]) winner = true;

    // check vertical
    if (grid[1] == grid[4] && grid[4] == grid[7]) winner = true;
    if (grid[2] == grid[5] && grid[5] == grid[8]) winner = true;
    if (grid[3] == grid[6] && grid[6] == grid[9]) winner = true;

    // check diagonal
    if (grid[1] == grid[5] && grid[5] == grid[9]) winner = true;
    if (grid[3] == grid[5] && grid[5] == grid[7]) winner = true;

    return winner;
  }

  static int GrabMove(char[] grid)
  {
    int move;
    char UserCharacter;

    while (true)
    {
      move = Console.Read() - 48;

      if (move > 0 && move < 10)
        {
          if (grid[move].Equals('X') || grid[move].Equals('O'))
          {
            System.Console.WriteLine("\nNice try, buster. {0} is already occupied. Gotta try again.", move);
          }

          else return move;
        }
        else
        {
          UserCharacter = Convert.ToChar(move + 48);
          System.Console.WriteLine("\n{0} is an invalid move. Please try again.", UserCharacter);
        }
    }
  }

  static int minimax(char[] grid, char player, int depth)
  {
    int score;
    int leaf = 9; // maximum depth for a tic tac toe game tree

    score = 1;

    System.Console.WriteLine("\n\nInside the **BRAIN of MINIMAX**");
    System.Console.WriteLine("Maximum game tree depth = {0} and the grid looks like this:", leaf);
    DrawColorGrid(grid);

    return score;
  }


  public static void Main()
  {
    int move;
    int depth;
    char[] grid = new char[10];
    char player;

    System.Console.WriteLine("\nWelcome to Tic Tac Toe\nYou know the rules. Here's the grid.\n");
    LoadGrid(grid);
    DrawColorGrid(grid);
    depth = 0;

    while (true)
    {
      player = 'X';
      Console.ForegroundColor = ConsoleColor.White;
      System.Console.WriteLine("\n\n{0}'s move. Which cell (1 thru 9) should {0} mark?", player);
      move = GrabMove(grid);
      UpdateGrid(move, player, grid);
      DrawColorGrid(grid);
      if (CheckWinner(grid))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\n\n*** {0} wins! ****\n", player);
            break;
          }

      player = 'O';

      minimax(grid, player, depth);

      Console.ForegroundColor = ConsoleColor.White;
      System.Console.WriteLine("\n\n{0}'s move. Which cell (1 thru 9) should {0} mark?", player);
      move = GrabMove(grid);
      UpdateGrid(move, player, grid);
      DrawColorGrid(grid);
      if (CheckWinner(grid))
          {
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("\n\n*** {0} wins! ****\n", player);
            break;
          }
      depth++;
    }
  }
}

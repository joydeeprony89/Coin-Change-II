using System.Collections.Generic;

namespace Coin_Change_II
{
  class Program
  {
    static void Main(string[] args)
    {
      int amount = 5;
      var coins = new int[] { 1, 2, 5 };
      Solution s = new Solution();
      s.Change(amount, coins);
    }
  }

  public class Solution
  {
    public int Change(int amount, int[] coins)
    {
      Dictionary<(int, int), int> visited = new Dictionary<(int, int), int>();

      int DFS(int i, int a)
      {
        // if a and amount are same
        if (a == amount) return 1;
        // index out of bound
        if (i >= coins.Length) return 0;
        // a out of bound amount
        if (a > amount) return 0;
        // if already visited
        if (visited.ContainsKey((i, a))) return visited[(i, a)];

        // 1, 2, 5 - to handle the duplicate combination like
        // 2, 2, 1 and 1, 2, 2 both the combination can return 5 but duplicate
        // so to handle this we take the current element and next element only
        // when take 1, we can take next 2 and 5 as well
        // when take 2 we can take next 5
        // when take 5 we can not take any after 5
        // you take the current index OR you take the next index


        // explanation -
        // why DFS(i, a + coins[i]) = when take current index amount would be current coin + previous amount
        // why DFS(i + 1, a) = when taking next (i+1) amount will same
        visited[(i, a)] = DFS(i, a + coins[i]) + DFS(i + 1, a);

        return visited[(i, a)];
      }

      return DFS(0, 0);
    }
  }
}

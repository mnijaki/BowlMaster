using System.Collections.Generic;

// Manage score.
public static class ScoreMaster
{
  // Return cumulative list of scores per round (like a normal bowling scroe card).
  public static List<int> CumulativeRoundsScores(List<int> rolls)
  {
    // List of scores per round.
    List<int> rounds_scores = new List<int>();
    // Total score.
    int total_score = 0;
    // Loop over rolls.
    foreach(int round_score in RoundsScores(rolls))
    {
      // Actualize total score.
      total_score+=round_score;
      // Add score to list.
      rounds_scores.Add(total_score);
    }
    // Return cumulative list of scores per round.
    return rounds_scores;
  } // End of CumulativeRoundsScores

  // Return list of scores per round (not cumulative).
  public static List<int> RoundsScores(List<int> rolls)
  {
    // List of scores per round.
    List<int> rounds_scores = new List<int>();
    // Loop over rolls.
    for(int i=1; i<rolls.Count; i+=2)
    {
      // If all rounds scores added then exit from loop.
      if(rounds_scores.Count==10)
      {
        break;
      }
      // If normal frame(round) then add score.
      if(rolls[i-1]+rolls[i]<10)
      {
        rounds_scores.Add(rolls[i-1]+rolls[i]);
      }
      // If at the end or list of rolls then exit loop.
      if(i>rolls.Count-2)
      {
        break;
      }
      // If strike.
      if(rolls[i-1]==10)
      {
        // Decrease iterator (becouse strike has only one bowl).
        i--;
        // Add score.
        rounds_scores.Add(10+rolls[i+1]+rolls[i+2]);
      }
      // If not a strike.
      else
      {
        // If spare then add score.
        if(rolls[i-1]+rolls[i]==10)
        {
          rounds_scores.Add(10+rolls[i+1]);
        }
      }
    }
    // Return list of scores per round.
    return rounds_scores;
  } // End of RoundsScores

} // End of ScoreMaster
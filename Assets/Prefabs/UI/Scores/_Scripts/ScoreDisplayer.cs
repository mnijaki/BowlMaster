using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display score.
public class ScoreDisplayer: MonoBehaviour
{
  // Array of texts holding scores on each rolls.
  public Text[] rolls_txt;
  // Array of texts holding scores on each rounds.
  public Text[] rounds_txt;

	// Initialization.
	private void Start()
  {
    // Clear texts.
    TextsClear();
  } // End of Start

  // Clear texts (Could be done in editor, but better is to have text filled in editor
  // and clear it in code. Thanks to that any changes to the display is easier).
  private void TextsClear()
  {
    foreach(Text txt in this.rolls_txt)
    {
      txt.text="";
    }
    foreach(Text txt in this.rounds_txt)
    {
      txt.text="";
    }
  } // TextsClear

  // Fill rolls scores into text components.
  public void RollsScoresFill(List<int> rolls)
  {
    // Format rolls scores.
    string scores = RollsScoresFormat(rolls);
    // Loop over formatted rolls scores.
    for(int i = 0; i<scores.Length; i++)
    {
      // Set text.
      this.rolls_txt[i].text=scores[i].ToString();
    }
  } // End of RollsScoresFill

  // Fill rounds scores into text components.
  public void RoundsScoresFill(List<int> rounds_scores)
  {
    for(int i=0; i<rounds_scores.Count; i++)
    {
      this.rounds_txt[i].text=rounds_scores[i].ToString();
    }
  } // End of RoundsScoresFill

  // Format rolls to normal score card.
  public static string RollsScoresFormat(List<int> rolls)
  {
    // Formatted scores.
    string scores="";
    // Roll number.
    int roll = 0;
    // Loop over rolls.
    for(int i=0; i<rolls.Count; i++)
    {
      // Actualize roll number.
      roll++;
      // If gutter roll.
      if(rolls[i]==0)
      {
        // Actualize score.
        scores+="-";
        // Skip loop step.
        continue;
      }
      // If spare in 21 roll and on 19 roll was strike.
      if((roll==21)&&(rolls[i-1]+rolls[i]==10)&&(rolls[i-2]==10))
      {
        // Actualize score.
        scores+="/";
        // Skip loop step.
        continue;
      }
      // If normal spare in second roll of round.
      if((roll%2==0)&&(rolls[i-1]+rolls[i]==10))
      {
        // Actualize score.
        scores+="/";
        // Skip loop step.
        continue;
      }
      // Strike in 10 round.
      if((roll>18)&&(rolls[i]==10))
      {
        // Actualize score.
        scores+="X";
        // Skip loop step.
        continue;
      }
      // If normal strike.
      if(rolls[i]==10)
      {
        // Actualize score.
        scores+="X ";
        // Actualize roll number.
        roll++;
        // Skip loop step.
        continue;
      }
      // Normal roll - actualize score.
      scores+=rolls[i].ToString();
    }
    // Return formatted scores.
    return scores;
  } // End of RollsScoresFormat

} // End of ScoreDisplayer
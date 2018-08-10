using System.Collections.Generic;
using UnityEngine;

// Aviable actions.
public static class ActionMaster
{
  // Enumeration of aviable actions.
  public enum Action {Tidy, Reset, EndRound, EndGame, Undefined}
  
  // Return next action.
  public static Action NextAction(List<int> rolls)
  {
    // Action to return.
    Action action = Action.Undefined;
    // Roll counter(for easier read of code).
    int roll = 0;
    // Loop over rolls list with numbers of knocked pins.
    for(int i = 0; i<rolls.Count; i++)
    {
      // If invalid pins number then throw error.
      if((rolls[i]<0) || (rolls[i]>10))
      {
        throw new UnityException("Invalid number of knocked pins");
      }
      // Actualize roll number.
      roll++;
      // If last roll.
      if(roll==21)
      {
        // Return 'EndGame'.
        return Action.EndGame;
      }
      // If on 19 roll player has knocked over 10 pins.
      if((roll==19)&&(rolls[i]==10))
      {
        // Set action to 'Reset' action (award 21 roll).
        action=Action.Reset;
        // Skip loop step.
        continue;
      }
      // If 20 roll.
      if(roll==20)
      {
        // If player has knocked all the pins in 19 roll and has not knocked all pins in 20 roll.
        if((rolls[i-1]==10)&&(rolls[i]<10))
        {
          // Retrun 'Tidy'.
          action=Action.Tidy;
          // Skip loop step.
          continue;
        }
        // If player has knocked all the pins in (19 + 20) roll or in (19 and 20) roll.
        if((rolls[i-1]+rolls[i])%10 == 0)
        {
          // Set action to 'Reset' action (award 21 roll).
          action=Action.Reset;
          // Skip loop step.
          continue;
        }
        // If player has not knocked all the pins in 19 and 20 roll.
        else
        {
          // Set action to 'EndGame'.
          action=Action.EndGame;
          // Skip loop step.
          continue;
        }
      }
      // If player knocked over 10 pins.
      if(rolls[i]==10)
      {
        // If this is first roll of the round (actualize roll number becouse there will be no second roll in this round).
        if(roll%2!=0)
        {
          // Actualize roll number.
          roll++;
        }
        // Set action to 'EndRound'.
        action=Action.EndRound;
        // Skip loop step.
        continue;
      }
      // If this is first roll of the round.
      if(roll%2!=0)
      {
        // Set action to 'Tidy'.
        action=Action.Tidy;
        // Skip loop step.
        continue;
      }
      // Set action to 'EndRound'.
      action=Action.EndRound;
    }
    // Return action.
    return action;
  } // End of NextAction

  } // End of ActionMaster
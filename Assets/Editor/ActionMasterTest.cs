using NUnit.Framework;
using System.Collections.Generic; // Enable operations on Lists.
using System.Linq; // Enable more flexible operations on Lists.

// Tests.
[TestFixture]
public class ActionMasterTest
{
  // Runs every time test is runned.
  [SetUp]
  public void Setup()
  {

  }

  [Test]
  public void PassingTest()
  {
    Assert.AreEqual(1,1);
  }

  [Test]
  public void BensTests_T01OneStrikeReturnsEndRound()
  {
    int[] rolls = { 10 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T02Bowl8ReturnsTidy()
  {
    int[] rolls = { 8 };
    Assert.AreEqual(ActionMaster.Action.Tidy,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T04Bowl28SpareReturnsEndRound()
  {
    int[] rolls = { 2,8 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T05CheckResetAtStrikeInLastFrame()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10 };
    Assert.AreEqual(ActionMaster.Action.Reset,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T06CheckResetAtSpareInLastFrame()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1 };
    Assert.AreEqual(ActionMaster.Action.Reset,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T07YouTubeRollsEndInEndGame()
  {
    int[] rolls = { 8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2,9 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T08GameEndsAtBowl20()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T09DarylBowl20Test()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,5 };
    Assert.AreEqual(ActionMaster.Action.Tidy,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T10BensBowl20Test()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,0 };
    Assert.AreEqual(ActionMaster.Action.Tidy,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T11NathanBowlIndexTest()
  {
    int[] rolls = { 0,10,5,1 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T12Dondi10thFrameTurkey()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,10,10 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void BensTests_T13ZeroOneGivesEndRound()
  {
    int[] rolls = { 0,1 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }



  // *********************************************************************************
  // MY TESTS
  // *********************************************************************************
  [Test]
  public void T01_OneStrikeReturnsEndRound()
  {
    int[] rolls = { 10 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T02_Roll8ReturnsTidy()
  {
    int[] rolls = { 8 };
    Assert.AreEqual(ActionMaster.Action.Tidy,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T03_Roll2And3ReturnsEndRound()
  {
    int[] rolls = { 2,3 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T04_Roll2And8ReturnsEndRound()
  {
    int[] rolls = { 2,8 };
    Assert.AreEqual(ActionMaster.Action.EndRound,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T05_CheckResetAtStrikeInLastTurn()
  {
    int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10 };
    Assert.AreEqual(ActionMaster.Action.Reset,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T06_YoutubeTest()
  {
    int[] rolls = { 8,2,10,3,4,10,2,8,10,10,8,0,10,8,2,10 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T08_StrikeAtSecondRoll()
  {
    int[] rolls = { 0,10,10,3,4,10,2,8,10,10,8,0,10,8,2,10 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T09_ReturnEndGame()
  {
    int[] rolls = { 8,2,10,3,4,10,2,8,10,10,8,0,10,10,2,5 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

  [Test]
  public void T10_ReturnEndGame()
  {
    int[] rolls = { 8,2,10,3,4,10,2,8,10,10,8,0,10,10,0,5 };
    Assert.AreEqual(ActionMaster.Action.EndGame,ActionMaster.NextAction(rolls.ToList()));
  }

} // End of ActionMasterTest
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Single static instance (singelton pattern).
  private static GameManager _instance;
  public static GameManager Instance
  {
    get
    {
      return GameManager._instance;
    }
  }
  // Ball.
  private Ball ball;
  // Pins counter.
  private PinsCounter pins_counter;
  // Pins setter.
  private PinsSetter pins_setter;
  // Score displayer.
  private ScoreDisplayer score_displayer;
  // Level manager.
  private LevelManager level_manager;
  // List of rolls list with numbers of knocked pins.
  private List<int> rolls = new List<int>();
  // Flag if roll is in progess.
  private bool is_roll_in_progress = false;

  // Awake (used to initialize any variables or states before the game starts).
  private void Awake()
  {
    // Save instance.
    GameManager._instance=this;
  } // End of Awake

  // Initialization.
  private void Start()
  {
    // Initialization.
    Init();
    // Load muisc.
    MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[1]);
  } // End of Start

  // Initialization.
  private void Init()
  {
    // Get ball.
    Instance.ball=GameObject.FindObjectOfType<Ball>();
    // Get pins counter.
    Instance.pins_counter=GameObject.FindObjectOfType<PinsCounter>();
    // Get pins setter.
    Instance.pins_setter=GameObject.FindObjectOfType<PinsSetter>();
    // Get score displayer.
    Instance.score_displayer=GameObject.FindObjectOfType<ScoreDisplayer>();
    // Get level manager.
    this.level_manager=GameObject.FindObjectOfType<LevelManager>();
  } // End of Init

  // Update (called once per frame).
  void Update()
  {
    // If user pressed escape.
    if(Input.GetKeyDown(KeyCode.Escape))
    {
      // Load main theme clip.
      MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[0]);
      // Return to main menu.
      GameObject.FindObjectOfType<LevelManager>().LoadLevelByName("01_MainMenu");
    }
  } // End of Update

  // Start roll.
  public void RollStart()
  {
    // Set flag if roll is in progress.
    Instance.is_roll_in_progress=true;
  } // End of RollStart

  // Get flag if roll is in progess.
  public bool IsRollInProgress()
  {
    return Instance.is_roll_in_progress;
  } // End of IsRollInProgress

  // Manage roll.
  public void ManageRoll(int pins_knocked)
  {
    // Add number of knocked pins to list of rolls.
    Instance.rolls.Add(pins_knocked);
    // Get next action.
    ActionMaster.Action action = ActionMaster.NextAction(Instance.rolls);    
    // Perform action on pins and lane.
    Instance.pins_setter.ActionPerform(action);
    // Reset ball.
    Instance.ball.Reset();
    // Set scores.
    Instance.score_displayer.RollsScoresFill(Instance.rolls);
    Instance.score_displayer.RoundsScoresFill(ScoreMaster.CumulativeRoundsScores(Instance.rolls));
    // If game has ended.
    if(action==ActionMaster.Action.EndGame)
    {
      // End game.
      GameEnd();
    }
  } // End of ManageRoll

  // When ball enter pins setter.
  public void OnPinsSetterBallEnter()
  {
    // Set color of standing count text.
    Instance.pins_counter.StandingCountTxtColorSet(Color.red);
  } // End of OnPinsSetterBallEnter

  // When ball exit pins setter.
  public void OnPinsSetterBallExit()
  {
    // Set flag if check of settling pins should happend.
    Instance.pins_counter.PinsCheck();
  } // End of OnPinsSetterBallExit

  // On animation end in pins setter.
  public void OnPinsSetterAnimEnd()
  {
    // Set falg if roll is in progress.
    Instance.is_roll_in_progress=false;
  } // End of OnPinsSetterAnimEnd

  // End game.
  private void GameEnd()
  {
    this.level_manager.LoadLevelByNameWithDelay("01_MainMenu",3);
    // Load muisc.
    MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[0]);
  } // End of GameEnd

} // End of GameManager
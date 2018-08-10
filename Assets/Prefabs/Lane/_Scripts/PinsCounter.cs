using UnityEngine;
using UnityEngine.UI;

public class PinsCounter : MonoBehaviour
{
  // Standing pins counter text.
  private Text standing_count_txt;
  // Number of remaining pins.
  private int pins_remained = 10;
  // Flag if check of settling pins should happend.
  private bool settled_check = false;
  // Last number of settling pins (pins that are shaking).
  private int last_settling_count = -1;
  // Time when counter of settling pins was last updated.
  private float last_settling_count_time = 0.0F;

  // Initialization.
  private void Start()
  {
    // Initialization.
    Init();
  } // End of Start

  // Initialization.
  private void Init()
  {
    // Get standing pins counter text.
    this.standing_count_txt=GameObject.Find("PinsCounterTxt").GetComponent<Text>();
  } // End of Init

  // Update (called once per frame).
  private void Update()
  {
    // If pins should be check if they are settled.
    if(this.settled_check)
    {
      // Check if pins are settled.
      PinsHaveSettledCheck();
    }
  } // End of Update

  // Reset.
  public void Reset()
  {
    // Reset number of remaining pins.
    this.pins_remained=10;
    // Change color of text holding number of standing pins.
    this.standing_count_txt.color=Color.white;
    // Reset text holding number of standing pins.
    this.standing_count_txt.text="10";
  } // End of Reset

  // Set color of standing count text.
  public void StandingCountTxtColorSet(Color color)
  {
    this.standing_count_txt.color=color;
  } // End of StandingCountTxtColorSet

  // Set flag if check of settling pins should happend.
  public void PinsCheck()
  {
    this.settled_check=true;
  } // End of PinsCheck

  // Count standing pins.
  private int StandingCount()
  {
    // Reset counter.
    int count = 0;
    // Loop through pins.
    foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
    {
      // If pin is standing.
      if(pin.IsStanding())
      {
        // Increase counter.
        count++;
      }
    }
    // Return number of standing pins.
    return count;
  } // End of StandingCount	

  // Check if pins are settled.
  private void PinsHaveSettledCheck()
  {
    // Get number of standing pins.
    int standing_count = StandingCount();
    // If number of settling pins have changed.
    if(standing_count!=this.last_settling_count)
    {
      // Actualize values.
      this.last_settling_count=standing_count;
      this.last_settling_count_time=Time.time;
      // Exit from function.
      return;
    }
    // If number of settling pins didn't change for more than 2.5 seconds.
    if(Time.time-this.last_settling_count_time>2.5F)
    {
      // Do stuff when pins have settled.
      PinsHaveSettled();
    }
  } // End of PinsHaveSettledCheck

  // Do stuff when pins have settled.
  private void PinsHaveSettled()
  {
    // Get number of standing pins.
    int standing_count = StandingCount();
    // Actualize text holding number of standing pins.
    this.standing_count_txt.text=standing_count.ToString();
    // Change color of text holding number of standing pins.
    this.standing_count_txt.color=Color.green;
    // Get number of knocked pins.
    int pins_knocked = this.pins_remained-standing_count;
    // Actualize number of remaining pins.
    this.pins_remained=standing_count;
    // Set number of settling pins(indicate that pins have settled).
    this.last_settling_count=-1;
    // Set flag if check of settling pins should happend.
    this.settled_check=false;
    // Manage roll.
    GameManager.Instance.ManageRoll(pins_knocked);
  } // End of PinsHaveSettled

  // On collision.
  private void OnTriggerExit(Collider other)
  {
    // If collision with pin.
    if(other.gameObject.GetComponent<Pin>())
    {
      // Destroy game object. 
      Destroy(other.gameObject);
    }
    // If collision with ball and check of settling pins is not happening.
    if((other.gameObject.GetComponent<Ball>())&&(!this.settled_check))
    {
      // Manage roll.
      GameManager.Instance.ManageRoll(0);
    }
  } // End of OnTriggerExit

} // End of PinsCounter

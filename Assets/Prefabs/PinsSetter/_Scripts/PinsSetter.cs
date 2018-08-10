using UnityEngine;

// Setter of pins.
public class PinsSetter : MonoBehaviour
{
  // Pins prefab.
  [HideInInspector]
  [SerializeField]
  private GameObject pins_prefab;
  // Pins.
  private GameObject pins;
  // Pins counter.
  private PinsCounter pins_counter;
  // Animator.
  private Animator anim;

  // Initialization.
  private void Start()
  {
    // Initialization.
    Init();
  } // End of Start

  // Initialization.
  private void Init()
  {
    // Get animator.
    this.anim=this.GetComponent<Animator>();
    // Get pins.
    this.pins=GameObject.Find("Pins");
    // Get pins counter.
    this.pins_counter=GameObject.FindObjectOfType<PinsCounter>();
  } // End of Init

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If collision with ball.
    if(other.gameObject.GetComponent<Ball>())
    {
      // Send event message to game manager.
      GameManager.Instance.OnPinsSetterBallEnter();
    }
  } // End of OnTriggerEnter

  // On collision.
  private void OnTriggerExit(Collider other)
  {
    // If collision with ball.
    if(other.gameObject.GetComponent<Ball>())
    {
      // Send event message to game manager.
      GameManager.Instance.OnPinsSetterBallExit();
    }
  } // End of OnTriggerExit

  // Perform action.
  public void ActionPerform(ActionMaster.Action action)
  {
    // Depending on the action.
    switch(action)
    {
      // Tidy.
      case ActionMaster.Action.Tidy:
      {
        // Run tidy animation.
        this.anim.SetTrigger("tidy_trg");
        // Break.
        break;
      }
      // Reset.
      case ActionMaster.Action.Reset:
      {
        // Run reset animation.
        this.anim.SetTrigger("reset_trg");
        // Break.
        break;
      }
      // End round. 
      case ActionMaster.Action.EndRound:
      {
        // Run reset animation.
        this.anim.SetTrigger("reset_trg");
        // Break.
        break;
      }
      // End game.
      case ActionMaster.Action.EndGame:
      {
        //
        //this.anim.SetTrigger("tidy_trg"); // TO_DO:?
        // Break.
        break;
      }
      // Default.
      default:
      {
        throw new UnityException("Action ["+action+"] is not supported");
      }
    }
  } // End of ActionPerform

  // Raise standing pins (animation event).
  private void OnAnimPinsRaise()
  {
    // Loop through pins.
    foreach(Pin pin in this.pins.GetComponentsInChildren<Pin>())
    {
      // Raise pin.
      pin.Raise();
    }
  } // End of OnAnimPinsRaise

  // Lower standing pins (animation event).
  private void OnAnimPinsLower()
  {
    // Loop through pins.
    foreach(Pin pin in this.pins.GetComponentsInChildren<Pin>())
    {
      // Lower pin.
      pin.Lower();
    }
  } // End of OnAnimPinsLower

  // Renew pins (animation event).
  private void OnAnimPinsRenew()
  {
    // Destroy old pins.
    Destroy(this.pins.gameObject);
    // Instatniate all pins.
    this.pins=Instantiate(this.pins_prefab,this.pins_prefab.transform.position,Quaternion.identity);
    // Loop through pins.
    foreach(Pin pin in this.pins.GetComponentsInChildren<Pin>())
    {
      // Raise pin.
      pin.Raise();
    }
    // Reset number of remaining pins.
    this.pins_counter.Reset();
  } // End of OnAnimPinsRenew

  // On animation end in pins setter (animation event).
  private void OnAnimPinsEnd()
  {
    // Send event message to game manager.
    GameManager.Instance.OnPinsSetterAnimEnd();
  } // End of OnAnimPinsEnd

} // End of PinsSetter
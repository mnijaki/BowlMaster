using UnityEngine;

// Pin.
public class Pin : MonoBehaviour
{
  // Rigidbody.
  private Rigidbody rbdy;
  // Starting position.
  private Vector3 start_pos;
  // Starting rotatation.
  private Quaternion start_rot;
  // Distance to raise standing pins.
  private float distance_to_raise = 40.0F;
  // Standing treshold.
  private float standing_treshold = 5.0F;

  // Awake (Initialization is in awake becouse when 'PinsRenew()' method
  // from 'PinsSetter' is called pin must have 'Init' luanched, 
  // when this code was in 'Start()' it was launched too late).
  void Awake()
  {
    // Initialization.
    Init();
  } // End of Awake

  // Initialization.
  private void Init()
  {
    // Get rigidbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Get starting position.
    this.start_pos=this.transform.position;
    // Get starting rotation.
    this.start_rot=this.transform.rotation;
  } // End of Init

  // Check if pin is standing.
  public bool IsStanding()
  {
    // Get rotation of pin in Euler angles.
    Vector3 rot_in_euler=this.transform.rotation.eulerAngles;
    // Get tilt values of pin ('y' and 'z' is irrelevant for checking if the pin has been knocked over).
    float new_x = 270.0F - rot_in_euler.x;
    float tilt_x = (new_x<180.0F) ? new_x : (360.0F-new_x);
    // If tilt values did not exceed treshold then return TRUE;
    if(Mathf.Abs(tilt_x)<this.standing_treshold)
    {
      return true;
    }
    // Return FALSE.
    return false;
  } // End of IsStanding

  // Raise pin.
  public void Raise()
  {
    // If pin is not standing then exit from function.
    if(!this.IsStanding())
    {
      return;        
    }
    // Disable gravity on pin.
    this.rbdy.useGravity=false;
    // Reset position and rotation of pin.
    this.transform.position=this.start_pos;
    this.transform.rotation=this.start_rot;
    // Reset physical values of pin.    
    this.rbdy.velocity=Vector3.zero;
    this.rbdy.angularVelocity=Vector3.zero;
    // Raise pin.
    this.transform.Translate(new Vector3(0.0F,this.distance_to_raise,0.0F),Space.World);
  } // End of Raise

  // Lower pin.
  public void Lower()
  {
    // Lower pin.
    this.transform.Translate(new Vector3(0.0F,-this.distance_to_raise,0.0F),Space.World);
    // Enable gravity on pin.
    this.rbdy.useGravity=true;
  } // End of Lower

} // End of Pin
using UnityEngine;

// Ball.
public class Ball : MonoBehaviour
{
  // Rigidbody.
  private Rigidbody rbdy;
  // Audio source.
  private AudioSource audio_source;
  // Ball starting position.
  private Vector3 start_pos;

  // Initialization.
  void Start()
  {
    // Initialization.
    Init();
  } // End of Start

  // Initialization.
  private void Init()
  {
    // Get audio source.
    this.audio_source=this.GetComponent<AudioSource>();
    // Get rigidbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Get ball starting position.
    this.start_pos=this.transform.position;
  } // End of Init

  // Launch ball.
  public void Launch(Vector3 velocity)
  {
    // If roll is in progess then exit from function.
    if(GameManager.Instance.IsRollInProgress())
    {
      return;
    }
    // If velocity is too low then exit from function.
    if(velocity.z<500)
    {
      return;
    }
    // Set initial velocity.
    this.rbdy.velocity=velocity;
    // Enable ball gravity.
    this.rbdy.useGravity=true;
    // Play sound.
    this.audio_source.Play();
    // Start roll.
    GameManager.Instance.RollStart();
  } // End of Launch

  // Move ball on 'x' axis.
  public void MoveOnX(float distance)
  {
    // If roll is in progess then exit from function.
    if(GameManager.Instance.IsRollInProgress())
    {
      return;
    }
    // Get new values.
    float x = Mathf.Clamp(this.transform.position.x+distance,-50.0F,50.0F);
    float y = this.transform.position.y;
    float z = this.transform.position.z;
    // Move ball.
    this.transform.position=new Vector3(x,y,z);
  } // End MoveOnX

  // Reset ball.
  public void Reset()
  {
    // Reset ball position.
    this.transform.position=this.start_pos;
    // Reset ball rotation.
    this.transform.rotation=Quaternion.identity;
    // Reset velocity.
    this.rbdy.velocity=Vector3.zero;
    this.rbdy.angularVelocity=Vector3.zero;
    // Reset gravity.
    this.rbdy.useGravity=false;
  } // End of Reset

} // End of Ball
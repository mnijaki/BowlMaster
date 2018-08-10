using UnityEngine;

// Camera.
public class MainCamera:MonoBehaviour
{
  // Ball.
  private GameObject ball;
  // Offset.
  private Vector3 offset;

  // Initialization
  private void Start()
  {
    // Initialization.
    Init();
  } // End of Start

  // Initialization.
  private void Init()
  {
    // Get ball.
    this.ball=GameObject.FindObjectOfType<Ball>().gameObject;
    // Get offset.
    this.offset=this.transform.position-this.ball.transform.position;
  } // End of Init

  // Update (called once per frame).
  private void Update()
  {
    // Actualization of position.
    PosAct();
  } // End of Update

  // Actualization of position.
  private void PosAct()
  {
    // If ball reach initial position of pins then exit from frunction. 
    if(this.ball.transform.position.z>=1829)
    {
      return;
    }
    // Actualize position.
    this.transform.position=this.ball.transform.position+this.offset;
  } // End of PosAct

} // End of MainCamera
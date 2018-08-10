using UnityEngine;

// Drag and drop(launch) of the ball.
[RequireComponent(typeof(Ball))]
public class BallDrag : MonoBehaviour
{
  // Ball.
  private Ball ball;
  // Starting position of drag.
  private Vector3 start_drag;
  // Starting time of drag.
  private float start_time;
  // Ending position of drag.
  private Vector3 end_drag;
  // Ending time of drag.
  private float end_time;

  // Initialization.
  private void Start()
  {
    // Initialization.
    Init();
	} // End of Start

  // Initialization.
  private void Init()
  {
    // Get ball.
    this.ball=this.GetComponent<Ball>();
  } // End of Init

  // Start of drag.
  public void DragStart()
  {
    // If there is no ball then exit from function.
    if(this.ball==null)
    {
      return;
    }
    // If roll is in progess then exit from function.
    if(GameManager.Instance.IsRollInProgress())
    {
      return;
    }
    // Get starting position of drag.
    this.start_drag=Input.mousePosition;
    // Get starting time of drag.
    this.start_time=Time.time;
  } // End of DragStart

  // End of drag (launch a ball).
  public void DragEnd()
  {
    // If roll is in progess then exit from function.
    if(GameManager.Instance.IsRollInProgress())
    {
      return;
    }
    // All of this came from v=s/t:
    //   v - is a vector of launching speed
    //   s_x = this.end_drag.x-this.start_drag.x;
    //   s_z = this.end_drag.y-this.start_drag.y;
    //   t = this.end_time-this.start_time
    // Get ending position of drag.
    this.end_drag=Input.mousePosition;
    // Get ending time of drag.
    this.end_time=Time.time;
    // Compute duration.
    float duration = this.end_time-this.start_time;
    // If duration is 0 then exit from function (cannot divide by zero).
    if(duration==0)
    {
      return;
    }
    // Compute speed in 'x' axis.
    float speed_x = (this.end_drag.x-this.start_drag.x)/duration;
    // Compute speed in 'z' axis, 'z' is calculated on 'y' values of 'TouchPad' game object,
    // because swiping from down to up on 'TouchPad' by user means that ball should go forward on 'z'. 
    float speed_z = (this.end_drag.y-this.start_drag.y)/duration;
    // Launch ball.
    this.ball.Launch(new Vector3(speed_x,0,speed_z));
  } // End of DragEnd

} // End of BallDrag
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

// Class that manage levels.
public class LevelManager : MonoBehaviour
{
  // Autoload time.
  [Range (0.0F,15.0F)]
  [Tooltip("Time of atomaticaly loading next scene. If 0.0 then next scene will not load automatically")]
  public float auto_load_time=0.0F;
  // Autoload clip.
  [Tooltip("Sound clip played when next scene load automatically.")]
  public AudioClip auto_load_clip;
  // Flag if loop autoload clip.
  [Tooltip("Flag if, sound clip played when next scene load automatically, should be looped.")]
  public bool auto_load_clip_loop=false;

  // Initialization.
  private void Start()
  {
    // If there is game object named "Level".
    if(GameObject.Find("Level")!=null)
    {
      // Actualize level text.
      GameObject.Find("Level").GetComponent<Text>().text=SceneManager.GetActiveScene().buildIndex.ToString();
    }
    // If win screen
    if(SceneManager.GetActiveScene().name=="1.3_Win")
    {
      // Load theme clip.
      MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[1]);
    }
    // If lose screen.
    if(SceneManager.GetActiveScene().name=="1.4_Lose")
    {
      // Load theme clip.
      MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[2]);
    }
    // If autoload next level.
    if(this.auto_load_time!=0.0)
    {
      // Autoload clip play.
      Invoke("AutoloadClipPlay",this.auto_load_time);
      // Autoload next level.
      Invoke("LoadNextLevel",this.auto_load_time);
    }
  } // End of Start

  // Autoload clip play.
  private void AutoloadClipPlay()
  {
    // If there is no autoload clip then exit from function.
    if(this.auto_load_clip==null)
    {
      return;
    }
    // If loop.
    if(this.auto_load_clip_loop)
    {
      // Play clip.
      MusicManager.Instance.ClipPlayWithLoop(this.auto_load_clip);
    }
    // If no loop.
    else
    {
      // Play clip.
      MusicManager.Instance.ClipPlay(this.auto_load_clip);
    }
  } // End of AutoloadClipPlay

  // Quit.
  public void Quit()
  {
    Application.Quit();
  } // End of Quit

  // Load level by name.
  public void LoadLevelByName(string name)
  {
    // Load scene.
    SceneManager.LoadScene(name);
  } // End of LoadLevelByName

  // Load level by name with delay.
  public void LoadLevelByNameWithDelay(string name,float time)
  {
    StartCoroutine(LoadLevelByNameWithDelay2(name,time));
  } // End of LoadLevelByNameWithDelay

  // Load level by name with delay.
  private IEnumerator LoadLevelByNameWithDelay2(string name,float time)
  {
    // Wait for 'time' seconds.
    yield return new WaitForSeconds(time);
    // Load next level.
    this.LoadLevelByName(name);
  } // End of LoadLevelByNameWithDelay2

  // Load next level.
  public void LoadNextLevel()
  {
    // If next scene index is higher than scene build settings (+2 becaouse scene indexes are counted from 0).
    if(SceneManager.GetActiveScene().buildIndex+2>SceneManager.sceneCountInBuildSettings)
    {
      // Log error.
      Debug.LogError("Can't load next scene. Scene index out of range");
      // Exit from function.
      return;
    }
    // Load next level.
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
  } // End of LoadNextLevel

  // Load next level with delay.
  public void LoadNextLevelWithDelay(float time)
  {
    StartCoroutine(LoadNextLevelWithDelay2(time));
  } // End of LoadNextLevelWithDelay

  // Load next level with delay.
  private IEnumerator LoadNextLevelWithDelay2(float time)
  {
    // Wait for 'time' seconds.
    yield return new WaitForSeconds(time);
    // Load next level.
    this.LoadNextLevel();
  } // End of LoadNextLevelWithDelay2

} // End of LevelManager
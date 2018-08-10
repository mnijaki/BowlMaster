using UnityEngine;

// Class that handle background music in the game.
public class MusicManager : MonoBehaviour
{
  // Single static instance of MusicManager (Singelton pattern).
  private static MusicManager _instance;
  public static MusicManager Instance
  {
    get
    {
      return MusicManager._instance;
    }
  }
  // Audio clips.
  public AudioClip[] audio_clips;
  // Audio source.
  private AudioSource audio_source;

  // Initialization.
  private void Start()
  {
    // Save instance.
    MusicManager._instance=this;
    // Make sure that music manager will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(Instance.gameObject);
    // Get audio source.
    Instance.audio_source=this.GetComponent<AudioSource>();
    // Set volume form player preferences.
    Instance.audio_source.volume=PlayerPrefsManager.MasterVolumeGet();
  } // End of Start

  // Play clip.
  public void ClipPlay(AudioClip clip)
  {
    // If no clip then exit form function.
    if(clip==null)
    {
      return;
    }
    // Load clip.
    Instance.audio_source.clip=clip;
    // Set 'off' loop on clip.
    Instance.audio_source.loop=false;
    // Play clip.
    Instance.audio_source.Play();
  } // End of ClipPlay

  // Play clip with loop.
  public void ClipPlayWithLoop(AudioClip clip)
  {
    // If no clip then exit form function.
    if(clip==null)
    {
      return;
    }
    // Load clip.
    Instance.audio_source.clip=clip;
    // Set 'on' loop on clip.
    Instance.audio_source.loop=true;
    // Play clip.
    Instance.audio_source.Play();
  } // End of ClipPlayWithLoop

  // Change volume.
  public void VolumeChange(float volume)
  {
    Instance.audio_source.volume=volume;
  } // End of VolumeChange

} // End of MusicManager
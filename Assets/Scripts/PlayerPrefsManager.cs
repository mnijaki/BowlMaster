using UnityEngine;
using UnityEngine.SceneManagement;

// Manage player preferences.
public class PlayerPrefsManager : MonoBehaviour
{
  // Master volume.
  const string MASTER_VOLUME_KEY = "master_volume";  
  // Level unlocks.
  const string LEVEL_UNLOCK_KEY = "level_unlocked_";
  // Difficulty.
  const string DIFFICULTY_KEY = "difficulty";

  // Set master volume.
  public static void MasterVolumeSet(float volume)
  {
    // If volume is in range.
    if((volume>=0.0F)&&(volume<=1.0F))
    {
      PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
    }
    // If volume out of range.
    else
    {
      Debug.LogError("Master volume out of range");
    }
  } // End of MasterVolumeSet

  // Get master volume.
  public static float MasterVolumeGet()
  {
    if(!PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
    {
      return 1.0F;
    }
    return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
  } // End of MasterVolumeGet

  // Unlock level.
  public static void LevelUnlcok(int level)
  {
    // If level is in range.
    if((level>0)&&(level<SceneManager.sceneCountInBuildSettings))
    {
      PlayerPrefs.SetInt(LEVEL_UNLOCK_KEY+level.ToString(),1);
    }
    // If level out of range.
    else
    {
      Debug.LogError("Level out of range");
    }
  } // End of LevelUnlcok

  // Return information if given level is unlocked.
  public static bool IsLevelUnlocked(int level)
  {
    // If level is in range.
    if((level>0)&&(level<SceneManager.sceneCountInBuildSettings))
    {
      return (PlayerPrefs.GetInt(LEVEL_UNLOCK_KEY+level)!=0);
    }
    // If level out of range.
    else
    {
      // Log error.
      Debug.LogError("Level out of range");
      // Return FALSE;
      return false;
    }
  } // End of IsLevelUnlocked

  // Set difficulty.
  public static void DifficultySet(int difficulty)
  {
    // If dificulty is in range.
    if((difficulty>0)&&(difficulty<4))
    {
      PlayerPrefs.SetInt(DIFFICULTY_KEY,difficulty);
    }
    // If dificulty out of range.
    else
    {
      Debug.LogError("Difficulty out of range");
    }
  } // End of DifficultySet

  // Get difficulty.
  public static int DifficultyGet()
  {
    return PlayerPrefs.GetInt(DIFFICULTY_KEY);
  } // End of DifficultyGet

} // End of MasterVolumeGet
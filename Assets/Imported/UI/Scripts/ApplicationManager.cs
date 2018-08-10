using UnityEngine;

// Aplication manager.
public class ApplicationManager : MonoBehaviour
{
  // Quit game.
	public void Quit () 
	{
		#if UNITY_EDITOR
		  UnityEditor.EditorApplication.isPlaying = false;
		#else
		  Application.Quit();
		#endif
	} // End of Quit

} // ApplicationManager
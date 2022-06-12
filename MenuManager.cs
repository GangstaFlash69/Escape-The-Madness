using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public bool menuDisplayed = false;
	public string MainMenu;

	//public Animator anim;

	void Update () 
	{
		if(Input.GetKey (KeyCode.Escape))
		 {
		    ActivatePauseMenu();
		 }
		 //else DeactivatePauseMenu();
	}

		public void ActivatePauseMenu()
		{

		//anim.SetBool ("MenuDisPlayed", true);
		}

	    public void DeactivatePauseMenu()
	    {
			menuDisplayed = false;

		 //anim.SetBool ("MenuDisPlayed", false);
	    }

		public void SaveGame()
		{

	    }

		public void ResumeGame()
		{
		DeactivatePauseMenu ();
	    }

		public void RestartGame()
		{
		SceneManager.LoadScene ("Scene1");
		}

		public void QuitGame()
		{
			Application.Quit();
		}
}

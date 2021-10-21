using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public void StartRestartGame()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
	}
	public void OpenMainScene()
	{
		SceneManager.LoadScene(0);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void OpenStageOne()
	{
		SceneManager.LoadScene(2);
	}

	public void OpenStageTwo()
	{
		SceneManager.LoadScene(3);
	}
	public void OpenStageThree()
	{
		SceneManager.LoadScene(4);
	}

	public void OpenStageFinish()
	{
		SceneManager.LoadScene(5);
	}

}

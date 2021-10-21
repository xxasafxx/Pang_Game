using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
	[Header("Timer")]
	[SerializeField] private float timeLeft;
	private bool isTimer = false;

	[Header("Score")]
	private static int score = 0;

	[Header("UI")]
	[SerializeField] private Text timerText;
	[SerializeField] private Text gameScoreText;
	[SerializeField] private Text gameOverscoreText;

	[Header("Panel")]
	[SerializeField] private GameObject gamePausePanel;
	[SerializeField] private GameObject gameOverPanel;
	[SerializeField] private GameObject gameWinPanel;
	[SerializeField] private GameObject gamePanel;

	[Header("StartDelay")]
	[SerializeField] private GameObject countDown;

	void Start()
	{
		score = 0;
		StartCoroutine("DelayStart");
	}

	IEnumerator DelayStart()
	{
		Time.timeScale = 0;
		float pauseTime = Time.realtimeSinceStartup + 3f;
		while(Time.realtimeSinceStartup < pauseTime)
		{
			yield return 0;
		}
		countDown.gameObject.SetActive(false);
		Time.timeScale = 1;
		isTimer = true;
	}

	void Update()
	{
		TimerUI();

		gameScoreText.text = "" + score;

		if (GameObject.FindGameObjectsWithTag("Bubble").Length < 1)
		{
			gameWinPanel.SetActive(true);
		}
	}

	private void TimerUI()
	{
		if (isTimer)
		{
			if (timeLeft > 0)
			{
				timeLeft -= Time.deltaTime;
				UpdateTimer(timeLeft);
			}
			else
			{
				ChackUI();
				timeLeft = 0;
				isTimer = false;
			}
		}
	}

	void UpdateTimer(float currentTime)
	{
		currentTime += 1;

		float minutes = Mathf.FloorToInt(currentTime / 60);
		float seconds = Mathf.FloorToInt(currentTime % 60);

		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	public static void AddPoints(int value) /// </add score when bubble pops/>
	{
		score += value;
	}

	
	/// ///////////////////////////////////////////////////////////
	/// </Game buttons for pause resume and game over>

	public void ChackUI()
	{
		gamePanel.SetActive(false);
		gameOverPanel.SetActive(true);
		gameOverscoreText.text = "" + score;
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		gamePausePanel.SetActive(true);
		
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		gamePausePanel.SetActive(false);
		
	}
}

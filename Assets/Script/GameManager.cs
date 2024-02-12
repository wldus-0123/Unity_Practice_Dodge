using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  // 게임오버시 활성화 할 게임오브젝트
    public Text timeText;            // 생존 시간을 표시할 텍스트
    public Text recordText;          // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime;       // 생존 시간
    private bool isGameOver;         // 게임오버 상태

	private void Start()
	{
        surviveTime = 0;
        isGameOver = false;
	}

	private void Update()
	{
		if(!isGameOver)
		{
			surviveTime += Time.deltaTime; // 생존시간 갱신
			timeText.text = "Time: " + (int)surviveTime;
		}
		else
		{
			gameoverText.SetActive(true);

			float bestTime = PlayerPrefs.GetFloat("BestTime");

			if (surviveTime > bestTime)
			{
				bestTime = surviveTime;
				PlayerPrefs.SetFloat("BestTime", bestTime);
			}

			recordText.text = "Best Time: " + (int)bestTime;
		}

	}

	private void OnRestart(InputValue value)
	{
		if(isGameOver)
		{
			SceneManager.LoadScene("SampleScene");
		}
	}

	public void EndGame()		// 게임오버 처리
	{
		isGameOver = true;
	}
}

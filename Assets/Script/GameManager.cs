using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  // ���ӿ����� Ȱ��ȭ �� ���ӿ�����Ʈ
    public Text timeText;            // ���� �ð��� ǥ���� �ؽ�Ʈ
    public Text recordText;          // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime;       // ���� �ð�
    private bool isGameOver;         // ���ӿ��� ����

	private void Start()
	{
        surviveTime = 0;
        isGameOver = false;
	}

	private void Update()
	{
		if(!isGameOver)
		{
			surviveTime += Time.deltaTime; // �����ð� ����
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

	public void EndGame()		// ���ӿ��� ó��
	{
		isGameOver = true;
	}
}

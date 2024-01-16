using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteObject;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private Transform playerTransform;

    private DateTime startTime;
    private bool triggered;


    void Awake()
    {
        startTime = DateTime.Now;
    }

    void Update()
    {
        if (playerTransform.localScale.x == -1) levelCompleteObject.transform.localScale = new Vector3(-1, 1, 1);
        else levelCompleteObject.transform.localScale = new Vector3(1, 1, 1);

        if (transform.childCount != 0) return;
        if (triggered) return;

        triggered = true;

        DateTime endTime = DateTime.Now;
        TimeSpan timeSpan = endTime - startTime;

        timeText.text = string.Format("Time Taken: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        levelCompleteObject.SetActive(true);
    }

    public void OnGameOver()
    {
        levelCompleteObject.SetActive(true);
        mainMenuButton.SetActive(false);
        headerText.text = "GAME OVER";
        timeText.text = string.Empty;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}

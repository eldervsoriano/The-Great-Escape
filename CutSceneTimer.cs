using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public string sceneLOAD;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)  // Adjusted condition to include equality check
        {
            remainingTime = 0;
            scenetoload(sceneLOAD); // Replace "NextSceneName" with the name of your next scene
        }

        void scenetoload(string sceneName)
        {
            Cursor.visible = true; // Ensure the cursor is visible
            Cursor.lockState = CursorLockMode.None; // Ensure the cursor is unlocked
            SceneManager.LoadScene(sceneName);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);  // Changed division factor from 300 to 60
        int seconds = Mathf.FloorToInt(remainingTime % 60);  // Corrected modulo operation
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Corrected format string
    }
}
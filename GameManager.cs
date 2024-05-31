using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text txtQuestUpdate;
    public Text txtInteractactMsg;

    public string gameOverLevel;
    public string nextLevel;

    public string firstQuest = "Find  a way to stop the ticking sound...";
    public float bombTimer;
    

    public bool isBombFound;
    public bool isBombDisarmed;
    public bool isCRDoorUnlocked;
    public bool isCRDoorKeyCollected;
    public bool isFlashLightCollected;
    public bool isScissorsFound;
    public bool isBatteryCollected;

    public string correctKeyCode;
    public string keyCode;
    public InputField code;


    void Start()
    {
        txtInteractactMsg.text = "What is that ticking sound, it's giving me goosebumps, \n I need to make it stop...";
        txtQuestUpdate.text = "Find a way to stop the ticking sound...";
        Invoke("Show1stMission", 2.5f);
    }

    void Show1stMission()
    {
        txtInteractactMsg.text = "";
        txtQuestUpdate.text = "Find a way to stop the ticking sound...";
    }

    void Update()
    {
        if (!isBombDisarmed)
        {
            bombTimer -= Time.deltaTime;
            if (isBombFound)
            {
                BombQuest();
            }
            if(bombTimer <= 0)
            {
                Debug.Log("The bomb exploded");
                SceneManager.LoadScene(gameOverLevel);
            }
        }

        else
        {
            txtQuestUpdate.text = "Find a way to get out";
            keyCode = code.text;
            if(keyCode == correctKeyCode)
            {Destroy(GameObject.Find("CRDoor"));
                Debug.Log("Loading Next Level");
                Invoke("LoadNext", 1.5f);
            }
        }
    }

    void LoadNext()
    {
        SceneManager.LoadScene(nextLevel);
    }

    void BombQuest()
    {
        float minutes = Mathf.Floor(bombTimer / 60);
        float seconds = bombTimer % 60;
        txtQuestUpdate.text = "Find something to cut the wires before the time runs out. " + minutes.ToString() + ":" + Mathf.RoundToInt(seconds);
    }
}

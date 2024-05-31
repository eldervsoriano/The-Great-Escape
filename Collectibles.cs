using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public bool isFlashlight;
    public bool isCRKey;
    public bool isScissors;
    public bool isBattery;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "Press [E] to pick-up";
        }
    }

    private void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isFlashlight)
                {
                    gameManager.isFlashLightCollected = true;
                    Invoke("ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }

                if (isCRKey)
                {
                    gameManager.isCRDoorKeyCollected = true;
                    Invoke("ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }

                if (isScissors)
                {
                    gameManager.isScissorsFound = true;
                    txtInteractMsg.text = "I found the scissors, I can now disarm the bomb";
                    Invoke("ClearMsg", 5.0f);
                    Destroy(this.gameObject);
                }

                if (isBattery)
                {
                    gameManager.isBatteryCollected = true;
                    txtInteractMsg.text = "I found the battery for the flashlight!";
                    Invoke("ClearMsg", 5.0f);
                    Destroy(this.gameObject);
                }
            }
        }
    }




    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "";
        }
    }

 

    void ClearMsg()
    {
        txtInteractMsg.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public GameObject bomb;
    public bool isExitDoor;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (gameManager.isScissorsFound)
            {
                txtInteractMsg.text = "Press [E] to cut the wires";
            }
            else
            {
                txtInteractMsg.text = "I need to find a way to cut the wires";
                gameManager.isBombFound = true;
            }
        }
    }

    private void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (gameManager.isScissorsFound)
                {
                    txtInteractMsg.text = "Phew, that was close, I need to get out of here";
                    Invoke("DelayClrScr", 1.5f);
                    gameManager.isBombDisarmed = true;
                    bomb.gameObject.SetActive(false);
                    Destroy(GameObject.Find("ExitDoor"));
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

    void DelayClrScr()
    {
        txtInteractMsg.text = "";
    }
}

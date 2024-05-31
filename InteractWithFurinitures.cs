using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithFurinitures : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtQuestUpdate;
    public Text txtInteractMsg;

    [Header("Interactive Furnitures")]
    
    public bool isDoor;
    public bool isBRStorage;
    public bool isMirrorCab;
    public bool isBed;
    public bool isCRDoor;
 
    public bool isToilet;
    public bool isScissors;
    public bool isBomb;
  

    [Header("Collectible Items")]
    public GameObject crKey;
    public GameObject Flashlight;
    public GameObject Lights;
    public GameObject bombObject;
    public GameObject battery;
    public GameObject scissors;


    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (!isMirrorCab)
            {
                txtInteractMsg.text = "Press [E] to Interact";
            }
            else
            {
                txtInteractMsg.text = "";
            }

            if (isBed)
            {
                if (gameManager.isFlashLightCollected)
                {
                    txtInteractMsg.text = "Press [E] to Interact";
                }
                else
                {
                    txtInteractMsg.text = "";
                }
            }

            if (isToilet)
            {
                if (!gameManager.isBombFound)
                {
                    txtInteractMsg.text = "Press [E] to Interact";
                }
                else
                {
                    txtInteractMsg.text = "";
                }
            }

            /*if (isScissors)
            {
                if (!gameManager.isScissorsFound)
                {
                    txtInteractMsg.text = "Press [E] to Interact";
                }
                else
                {
                    txtInteractMsg.text = "";
                }
            }*/


        }

    }

    private void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isCRDoor)
                {
                    if (gameManager.isCRDoorKeyCollected)
                    {
                        txtInteractMsg.text = "";
                        Destroy(GameObject.Find("CRDoor"));
                    }
                    else
                    {
                        txtInteractMsg.text = "It's locked, I need to find something to open it...";
                    }
                }

                else if (isBRStorage)
                {
                    if (gameManager.isBatteryCollected)
                    {
                        txtInteractMsg.text = "";
                        Destroy(GameObject.Find("Flashlight"));
                        Lights.gameObject.SetActive(true);
                        crKey.gameObject.SetActive(true);


                    }
                    else
                    {
                        txtInteractMsg.text = "A flashlight... But I need to collect a battery first";
                    }
                }

                else if (isBed)
                {
                    if (gameManager.isFlashLightCollected)
                    {
                        crKey.gameObject.SetActive(true);
                        txtInteractMsg.text = "A key, I'll try this on the CR Door";
                    }
                    if (gameManager.isFlashLightCollected || crKey.gameObject == null)
                    {
                        txtInteractMsg.text = "There's nothing here to collect...";
                    }
                }

                else if (isToilet)
                {
                    if (!gameManager.isBombDisarmed)
                    {
                        bombObject.gameObject.SetActive(true);
                        
                    }
                }

                
            }
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = ""; // Clear the text
        }
    }





}

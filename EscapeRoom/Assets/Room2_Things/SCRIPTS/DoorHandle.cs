using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandle : MonoBehaviour
{
   
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ToastController toastController;
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool animateTrigger = true;

    private static List<Item> Items = new List<Item>();
    private bool itemWasFound = false;
 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Green Key") && animateTrigger)
            {
                DisplayInfo2();
                myDoor.Play("MetalicDoorAnimation", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else
                DisplayInfo();
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("I don't have key to exit this room!");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("Congrats! You can leave now.");
        toastController.makeKeyIsMissingToast();
    }
}

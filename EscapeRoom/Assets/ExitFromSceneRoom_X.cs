using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFromSceneRoom_X : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ToastController toastController;

    private static List<Item> Items = new List<Item>();
    private bool itemWasFound = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Key_RoomX"))
                sc.changeSceneTo("Playground");
            else
                DisplayInfo();
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("You need to pick up the key in order to leave the room!");
        toastController.makeKeyIsMissingToast();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenDoorOpenScript : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ToastController toastController;

    private static List<Item> Items = new List<Item>();
    private bool itemWasFound = false;
    GameObject door;
    BoxCollider collider;

    void Start()
    {
        door = GameObject.FindWithTag("HiddenRoomDoor");
        collider = door.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Key_HiddenRoom"))
            {
                DisplayInfo2();
                GetComponent<Collider>().isTrigger = true;
                //Destroy(door);
                door.transform.position = new Vector3(-25.49f, 0.013f, 1.13f);
                door.transform.Rotate(0, 131.39f, 0);
                collider.isTrigger = false;
            }
            else
                DisplayInfo();
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("You don't have key to enter the hidden room!");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("Door to hidden room opened!");
        toastController.makeKeyIsMissingToast();
    }
}

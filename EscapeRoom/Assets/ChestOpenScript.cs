using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestOpenScript : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ToastController toastController;

    private static List<Item> Items = new List<Item>();
    private bool itemWasFound = false;
    BoxCollider collider;
    GameObject lid;
    GameObject notebook;

    void Start()
    {
        notebook = GameObject.FindWithTag("NotePad");
        collider = notebook.GetComponent<BoxCollider>();
        lid = GameObject.FindWithTag("ChestLid");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Key_Chest"))
            {
                DisplayInfo2();
                collider.isTrigger = true;
                Destroy(lid);
            }
            else
                DisplayInfo();
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("You don't have key!");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("Chest opened!");
        toastController.makeKeyIsMissingToast();
    }
}

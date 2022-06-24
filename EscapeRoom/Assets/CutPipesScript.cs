using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutPipesScript : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ToastController toastController;

    private static List<Item> Items = new List<Item>();
    private bool itemWasFound = false;
    GameObject pipe1;
    GameObject pipe2;

    void Start()
    {
        pipe1 = GameObject.FindWithTag("Pipe_1");
        pipe2 = GameObject.FindWithTag("Pipe_2");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Saw_RoomX"))
            {
                DisplayInfo2();
                GetComponent<Collider>().isTrigger = true;
                Destroy(pipe1);
                Destroy(pipe2);
            }
            else
                DisplayInfo();
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("You'll need to find a saw to cut the pipes. Recently they have been used to repair pipes above the library");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("You have successfully cut the pipes!");
        toastController.makeKeyIsMissingToast();
    }
}

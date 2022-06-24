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
    GameObject character;
    BoxCollider collider;

    void Start()
    {
        pipe1 = GameObject.FindWithTag("Pipe_1");
        pipe2 = GameObject.FindWithTag("Pipe_2");
        character = GameObject.FindWithTag("character");
        collider = character.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inventoryManager.IsGivenItemInEq("Saw_RoomX"))
            {
                DisplayInfo2();
                Destroy(pipe1);
                Destroy(pipe2);
            }
            else
            {
                DisplayInfo();
                collider.isTrigger = true;
            }
        }
    }

    private void DisplayInfo()
    {
        toastController.setKeyIsMissingToastContent("I need to cut the pipes. Maybe i should ask somebody for help... ");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("I have successfully cut the pipes!");
        toastController.makeKeyIsMissingToast();
    }
}

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTip : MonoBehaviour
{


    [SerializeField]
    GameObject panel;
    [SerializeField]
    bool showPanel = false;
    [SerializeField] InventoryManager inventoryManager;
    FirstPersonController FPC;
    bool inside = false;
    Text description;

    StarterAssets.StarterAssetsInputs mouseLook;

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    // Start is called before the first frame update
    void Start()
    {
        FPC = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        description = GameObject.Find("TipDescription").GetComponent<Text>();
        panel.SetActive(showPanel);
        inside = false;
        mouseLook = GameObject.Find("PlayerCapsule").GetComponent<StarterAssets.StarterAssetsInputs>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.IsGivenItemInEq("Battery_1") && inventoryManager.IsGivenItemInEq("Battery_2"))
            description.text = "\nLook at the pictures and then at the safe.\n\nThis should point you in the direction of guessing the code";
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            openPanel();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            closePanel();
        }
    }
    private void openPanel()
    {
        showPanel = true;
        panel.SetActive(showPanel);
        mouseLook.cursorLocked = !mouseLook.cursorLocked;
        FPC.stopStartCameraRotationUpdate = false;
        if (!mouseLook.cursorLocked)
        {
            mouseLook.cursorLocked = true;
            mouseLook.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void closePanel()
    {
        FPC.stopStartCameraRotationUpdate = true;
        showPanel = false;
        panel.SetActive(showPanel);
        mouseLook.cursorLocked = true;
        mouseLook.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenDoorOpenScript : MonoBehaviour
{
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
        toastController.setKeyIsMissingToastContent("I don't have key to enter the room!");
        toastController.makeKeyIsMissingToast();
    }
    private void DisplayInfo2()
    {
        toastController.setKeyIsMissingToastContent("I have opened the door!");
        toastController.makeKeyIsMissingToast();
    }
}*/
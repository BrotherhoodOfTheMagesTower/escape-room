using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool showInventory = false;
    [SerializeField] InventoryManager inventoryManager;
    FirstPersonController FPC;
    StarterAssets.StarterAssetsInputs mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        //FPC = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        FPC = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        mouseLook = GameObject.Find("PlayerCapsule").GetComponent<StarterAssets.StarterAssetsInputs>();

        panel.SetActive(showInventory);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryManager.ListItems();
            openInventory();
        }

        if(showInventory == true && Input.GetKeyDown(KeyCode.Escape))
        {
            closeInventory();
        }
    }

    private void openInventory()
    {
        showInventory = true;
        panel.SetActive(showInventory);
        mouseLook.cursorLocked = !mouseLook.cursorLocked;
        if (!mouseLook.cursorLocked)
        {
            mouseLook.cursorLocked = true;
            mouseLook.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void closeInventory()
    {
        showInventory = false;
        panel.SetActive(showInventory);
        mouseLook.cursorLocked = true;
        mouseLook.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void handleCloseButton()
    {
        closeInventory();
    }
}

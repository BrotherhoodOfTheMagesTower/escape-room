using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject inspectionPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject aboutProjectPanel;
    [SerializeField] Text itemDescription;
    [SerializeField] Image itemSprite;
    [SerializeField] bool showInventory = false;
    [SerializeField] bool showMenuPanel = false;
    [SerializeField] bool showAboutProjectInfo = false;
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
        if(showMenuPanel == false && Input.GetKeyDown(KeyCode.I))
        {
            inventoryManager.ListItems();
            openInventory();
        }

        if(showInventory == true && Input.GetKeyDown(KeyCode.Escape))
        {
            closeInventory();
        }

        if (showMenuPanel && Input.GetKeyDown(KeyCode.Escape))
        {
            closeMenu();
        }
        else if (!showInventory && Input.GetKeyDown(KeyCode.Escape))
        {
            openMenu();
        }
    }

    private void openInventory()
    {
        StartCoroutine(DipslayInventoryPanel());

        // Disable mouse look
        FPC.stopStartCameraRotationUpdate = false;
        mouseLook.cursorLocked = !mouseLook.cursorLocked;
        if (!mouseLook.cursorLocked)
        {
            mouseLook.cursorLocked = true;
            mouseLook.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void openMenu()
    {
        showMenuPanel = true;
        menuPanel.SetActive(true);

        // Disable mouse look
        FPC.stopStartCameraRotationUpdate = false;
        mouseLook.cursorLocked = !mouseLook.cursorLocked;
        if (!mouseLook.cursorLocked)
        {
            mouseLook.cursorLocked = true;
            mouseLook.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void closeMenu()
    {
        mouseLook.cursorLocked = true;
        mouseLook.cursorInputForLook = true;
        FPC.stopStartCameraRotationUpdate = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        showAboutProjectInfo = showMenuPanel = false;
        menuPanel.SetActive(false);
        aboutProjectPanel.SetActive(false);
    }

    public void openInspectionPanel(int ItemId)
    {
        if (showInventory)
        {
            List<int> itemIds = new List<int>();
            foreach (var item in InventoryManager.Items)
            {
                itemIds.Add(item.id);
            }

            if (itemIds.Contains(ItemId))
            {
                panel.SetActive(false);
                inspectionPanel.SetActive(true);

                var currentItem = InventoryManager.Items.Find(i => i.id == ItemId);

                itemDescription.text = currentItem.content;
                itemSprite.sprite = currentItem.icon;
            }
            else
            {
                Debug.Log($"Error in openInspectionPanel() method. Item with {ItemId} not found!");
            }
        }
    }

    private void closeInventory()
    {
        StartCoroutine(CloseInventoryPanel());
        mouseLook.cursorLocked = true;
        mouseLook.cursorInputForLook = true;
        FPC.stopStartCameraRotationUpdate = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void handleCloseButton()
    {
        closeInventory();
    }

    public void handleReturnButton()
    {
        inspectionPanel.SetActive(false);
        panel.SetActive(true);
    }

    IEnumerator DipslayInventoryPanel()
    {
        showInventory = true;
        panel.SetActive(showInventory);
        for (float alpha = 0.0f; alpha <= 0.67f; alpha += 0.05f)
        {
            var image = panel.GetComponent<Image>();
            var color = image.color;
            color.a = alpha;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CloseInventoryPanel()
    {
        for (float alpha = 0.67f; alpha >= 0.1f; alpha -= 0.05f)
        {
            var image = panel.GetComponent<Image>();
            var color = image.color;
            color.a = alpha;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        showInventory = false;
        panel.SetActive(showInventory);
        inspectionPanel.SetActive(showInventory);
    }
}

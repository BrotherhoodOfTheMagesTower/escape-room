using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class AskToRepairCar : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool showPanel = false;
    [SerializeField] int desiredCollectedItemId;
    //[SerializeField] Item desiredCollectedItem;
    FirstPersonController FPC;
    private bool inside = false;
    private Text description;
    private StarterAssetsInputs mouseLook;


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

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && InventoryManager.Items.Find(i => i.id == desiredCollectedItemId))
        {
            OpenPanel();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ClosePanel();
        }
    }
    private void OpenPanel()
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

    private void ClosePanel()
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


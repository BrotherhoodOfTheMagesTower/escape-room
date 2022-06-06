
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTip : MonoBehaviour
{


    [SerializeField]
    GameObject panel;
    [SerializeField]
    bool showPanel = false;
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
        showPanel = false;
        panel.SetActive(showPanel);
        mouseLook.cursorLocked = true;
        mouseLook.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

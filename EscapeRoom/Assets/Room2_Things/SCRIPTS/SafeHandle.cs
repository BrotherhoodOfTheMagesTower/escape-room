using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeHandle : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    bool showPanel = false;
    FirstPersonController FPC;
    bool inside = false;
    InputField inputFieldObj;
    Text resultLabel;
    Text inputLabel;
    Text hintLabel;
    Text hintPlaceHolder;
    GameObject key;
    GameObject exitArea;

    StarterAssets.StarterAssetsInputs mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        FPC = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        inputFieldObj = GameObject.Find("InputField").GetComponent<InputField>();
        resultLabel = GameObject.Find("ResultLabel").GetComponent<Text>();
        inputLabel = GameObject.Find("InputText").GetComponent<Text>();
        hintPlaceHolder = GameObject.Find("HintPlaceholder").GetComponent<Text>();
        hintLabel = GameObject.Find("HintLabel").GetComponent<Text>();
        //exitArea = GameObject.Find("Exit_RoomX");
        key = GameObject.Find("Key_Room2");
        panel.SetActive(showPanel);
        inside = false;
        key.transform.position = new Vector3(15.87f, 3.142926f, 30.58f); //ensure that key is outside scene when the player enters the scene
        //exitArea.transform.position = new Vector3(30.29f, 24.11f, -31.809f); //ensure that exit area is outside scene when the player enters the scene
        //GameObject.Find("Exit_Light").GetComponent<Light>().enabled = false; //ensure that the exit light is turned off
        mouseLook = GameObject.Find("PlayerCapsule").GetComponent<StarterAssets.StarterAssetsInputs>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true && showPanel == true && Input.GetKeyDown(KeyCode.Return))
        {
            if (inputFieldObj.GetComponent<InputField>().text.Equals("666"))
            {
                resultLabel.GetComponent<Text>().color = Color.green;
                resultLabel.GetComponent<Text>().text = "Correct code!";
                hintLabel.GetComponent<Text>().text = " Get the key and exit room.";
                //GameObject.Find("Exit_Light").GetComponent<Light>().enabled = true;
                key.transform.position = new Vector3(15.87f, 3.142926f, 32.535f); //set key's position on safe
               // exitArea.transform.position = new Vector3(30.29f, 13.65f, -31.809f); //set exit area position (visible for player)
            }
            else
            {
                resultLabel.GetComponent<Text>().color = Color.red;
                resultLabel.GetComponent<Text>().text = "Wrong code!";
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            openPanel();
            inside = !inside;
            inputLabel.GetComponent<Text>().enabled = true;
            inputLabel.GetComponent<Text>().text = "";
            hintPlaceHolder.GetComponent<Text>().enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            closePanel();
            inside = !inside;
            resultLabel.GetComponent<Text>().text = "";
            inputLabel.GetComponent<Text>().text = "";
            inputLabel.GetComponent<Text>().enabled = false;
            hintPlaceHolder.GetComponent<Text>().enabled = true;
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

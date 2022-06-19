using StarterAssets;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class FixCar : MonoBehaviour
{
    public static bool CanEnterCar { get; set; } = false;
    [SerializeField] GameObject panel;
    [SerializeField] bool showPanel = false;
    [SerializeField] int hammerId;
    [SerializeField] int fuelId;
    [SerializeField] ToastController toastController;
    private bool codeHasBeenEntered = false;
    FirstPersonController FPC;
    bool inside = false;
    InputField inputFieldObj;
    Text resultLabel;
    Text inputLabel;
    Text hintLabel;
    Text hintPlaceHolder;
    StarterAssetsInputs mouseLook;
    private readonly string correctCode = "756";
    private Stopwatch stopWatch;

    // Start is called before the first frame update
    void Start()
    {
        FPC = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        inputFieldObj = GameObject.Find("InputField").GetComponent<InputField>();
        resultLabel = GameObject.Find("ResultLabel").GetComponent<Text>();
        inputLabel = GameObject.Find("InputText").GetComponent<Text>();
        hintPlaceHolder = GameObject.Find("HintPlaceholder").GetComponent<Text>();
        hintLabel = GameObject.Find("HintLabel").GetComponent<Text>();
        panel.SetActive(showPanel);
        inside = false;
        mouseLook = GameObject.Find("PlayerCapsule").GetComponent<StarterAssetsInputs>();
        stopWatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true && showPanel == true && Input.GetKeyDown(KeyCode.Return))
        {
            if (inputFieldObj.GetComponent<InputField>().text.Equals(correctCode))
            {
                stopWatch.Start();
                resultLabel.GetComponent<Text>().color = Color.green;
                resultLabel.GetComponent<Text>().text = "Correct code!";
                codeHasBeenEntered = true;
                if (InventoryManager.Items.Find(i => i.id == fuelId))
                {
                    hintLabel.GetComponent<Text>().text = "The car is now repaired To enter car press \"E\"";
                    CanEnterCar = true;
                }
                else
                {
                    hintLabel.GetComponent<Text>().text = "The car is now repaired";
                }
            }
            else
            {
                resultLabel.GetComponent<Text>().color = Color.red;
                resultLabel.GetComponent<Text>().text = "Wrong code!";
                codeHasBeenEntered = false;
            }
        }
        if (stopWatch.ElapsedMilliseconds > 5000)
        {
            ClosePanel();
            stopWatch.Stop();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (GettingInOutOfCars.InCar) return;

        if (codeHasBeenEntered && InventoryManager.Items.Find(i => i.id == fuelId))
        {
            toastController.setToastContent($"To enter car press \"E\"");
            toastController.makeToast();
            CanEnterCar = true;
        }
        else if (codeHasBeenEntered && !InventoryManager.Items.Find(i => i.id == fuelId))
        {
            toastController.setToastContent($"Fuel level is too low to start the car.");
            toastController.makeToast();
            CanEnterCar = false;
        }
        else
        {
            if (col.gameObject.tag == "Player" && InventoryManager.Items.Find(i => i.id == hammerId))
            {
                OpenPanel();
                inside = !inside;
                inputLabel.GetComponent<Text>().enabled = true;
                inputLabel.GetComponent<Text>().text = "";
                hintPlaceHolder.GetComponent<Text>().enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ClosePanel();
            inside = !inside;
            resultLabel.GetComponent<Text>().text = "";
            inputLabel.GetComponent<Text>().text = "";
            inputLabel.GetComponent<Text>().enabled = false;
            hintPlaceHolder.GetComponent<Text>().enabled = true;
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


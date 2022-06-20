using UnityEngine;

public class EscapeGarage : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] string sceneName;
    [SerializeField] int keyId;
    [SerializeField] ToastController toastController;
    void OnTriggerEnter(Collider other)
    {
        if (InventoryManager.Items.Find(k => k.id == keyId))
        {
            sc.changeSceneTo(sceneName);
        }
        else
        {
            toastController.setToastContent("Doors are locked");
            toastController.makeToast();
        }
    }
}

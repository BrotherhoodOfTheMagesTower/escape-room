using UnityEngine;

public class EscapeGarage : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] string sceneName;
    [SerializeField] int keyId;
    [SerializeField] int hammerId;
    [SerializeField] int fuelId;
    [SerializeField] ToastController toastController;
    void OnTriggerEnter(Collider other)
    {
        if (InventoryManager.Items.Find(k => k.id == keyId))
        {
            //Remove unnecessary items before moving back to main scene
            InventoryManager.Items.Remove(InventoryManager.Items.Find(h => h.id == hammerId));
            InventoryManager.Items.Remove(InventoryManager.Items.Find(f => f.id == fuelId));
            sc.changeSceneTo(sceneName);
        }
        else
        {
            toastController.setToastContent("Doors are locked");
            toastController.makeToast();
        }
    }
}

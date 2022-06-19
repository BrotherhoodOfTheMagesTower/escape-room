using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] Item newItem;
    [SerializeField] ToastController toastController;

    private void Pickup()
    {
        //toastController = toastPanel.GetComponent<ToastController>();
        inventory.Add(newItem);
        Destroy(gameObject);
        toastController.setToastContent($"I found {newItem.itemName}");
        toastController.makeToast();
    }
    // Start is called before the first frame update
    void Start()
    {
        //toastController = toastPanel.GetComponent<ToastController>();
    }

    private void OnMouseEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Pickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        Pickup();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

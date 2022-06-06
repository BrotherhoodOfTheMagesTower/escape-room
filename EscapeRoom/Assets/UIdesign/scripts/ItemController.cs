using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    private InventoryController currentController;

    // Start is called before the first frame update
    void Start()
    {
       //currentController = GameObject.Find("UI_InventoryController").GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItem(Item newItem)
    {
        item = newItem;
    }

    public void onItemClick()
    {
        currentController = GameObject.Find("UI_InventoryController").GetComponent<InventoryController>();
        currentController.openInspectionPanel(item.id);
    }
}

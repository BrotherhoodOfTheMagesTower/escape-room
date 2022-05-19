using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] Item newItem;

    private void Pickup()
    {
        inventory.Add(newItem);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Pickup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

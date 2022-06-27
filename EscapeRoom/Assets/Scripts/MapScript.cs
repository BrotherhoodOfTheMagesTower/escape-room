using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Transform player;
    public Material green;
    [SerializeField] public GameObject roomXIcon;
    [SerializeField] public GameObject garageIcon;
    [SerializeField] public GameObject woodenHouseIcon;

    void Update()
    {
        if (InventoryManager.Items.Find(i => i.id == 3))
            roomXIcon.GetComponent<MeshRenderer>().material = green; ;
        if (InventoryManager.Items.Find(i => i.id == 12))
            garageIcon.GetComponent<MeshRenderer>().material = green;
        if (InventoryManager.Items.Find(i => i.id == 73))
            woodenHouseIcon.GetComponent<MeshRenderer>().material = green;
    }
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90.0f, player.eulerAngles.y, 0.0f);
    }
}
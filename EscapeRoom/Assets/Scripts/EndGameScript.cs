using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EngGameScript : MonoBehaviour
{
    [SerializeField] public GameObject gamer;
    [SerializeField] public GameObject helicopter;
    bool inside = false;
    public float speedUp = 0.5f;

    void Start()
    {
        inside = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (InventoryManager.Items.Find(i => i.id == 3) && InventoryManager.Items.Find(i => i.id == 12) && InventoryManager.Items.Find(i => i.id == 73))
        {
            inside = true;
            gamer.transform.position = (new Vector3(-97.217f, -6.97f, -308.172f));
            GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>().enabled = false;
            // you win
        }
        else
        {
            //you must find keys
        }
    }

    void Update()
    {
        if (inside == true && Input.GetKey(KeyCode.W))
        {
            gamer.transform.position += (new Vector3(0, speedUp, 0));
            helicopter.transform.position += (new Vector3(0, speedUp, 0));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] public GameObject gamer;
    [SerializeField] public GameObject helicopter;
    [SerializeField] ToastController toastController;
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
            gamer.transform.position = helicopter.transform.position;
            gamer.transform.position += new Vector3(1.85f, 2.0f, 0.0f);
            gamer.transform.rotation = helicopter.transform.rotation;
            GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>().enabled = false;
            toastController.setToastContent("Congrats! You won!");
            toastController.makeToast();
        }
        else
        {
            toastController.setToastContent("First find keys!");
            toastController.makeToast();
        }
    }

    void Update()
    {
        if (inside == true && helicopter.transform.position.y < 20)
        {
            Vector3 a = (new Vector3(0, speedUp, 0));
            gamer.transform.position += a;
            helicopter.transform.position += a;
        }
    }
}
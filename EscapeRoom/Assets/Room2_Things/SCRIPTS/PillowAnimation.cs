using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowAnimation : MonoBehaviour
{
     [SerializeField] private Animator myPillow = null;
     [SerializeField] private bool animateTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (animateTrigger)
            {
                myPillow.Play("PillowAnimation",0,0.0f);
                gameObject.SetActive(false);
            }
        }
    }





}

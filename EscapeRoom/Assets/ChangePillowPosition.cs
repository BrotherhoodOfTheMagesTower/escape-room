/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ChangePillowPosition : MonoBehaviour
{
    public GameObject Pillow;
    bool first = true;


    // Start is called before the first frame update
    void Start()
    {
        Pillow = GameObject.Find("coussin4");

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pillow" && first)
        {
          
           Pillow.transform.position = new Vector3(-0.3f, 0.436f, 0.43f);
            
           first = false;
        }
        
    }
}*/

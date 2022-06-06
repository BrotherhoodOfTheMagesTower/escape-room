using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ChangePillowPosition : MonoBehaviour
{
    public GameObject Pillow;
    bool first = true;
    public float downZ = 0.001f;
    public float downX = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        Pillow = GameObject.Find("coussin4");

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pillow" && first)
        {
            for (int i = 0; i < 2; i++)
            {
                Pillow.transform.position += (new Vector3(-downX, 0, -downZ));
            }
        }
        
    }
   

    // Update is called once per frame
    void Update()
    {

       
       
    
    }
}

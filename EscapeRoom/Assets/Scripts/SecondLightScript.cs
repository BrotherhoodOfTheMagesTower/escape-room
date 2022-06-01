using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLightScript : MonoBehaviour
{
	bool inside = false;

	void Start()
	{
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "SecondLight")
		{
			col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "SecondLight")
		{
			inside = !inside;
		}
	}

}

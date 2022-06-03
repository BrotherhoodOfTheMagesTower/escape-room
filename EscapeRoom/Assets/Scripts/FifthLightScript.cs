using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthLightScript : MonoBehaviour
{
	bool inside = false;

	void Start()
	{
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "FifthLight")
		{
			col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "FifthLight")
		{
			inside = !inside;
		}
	}
}

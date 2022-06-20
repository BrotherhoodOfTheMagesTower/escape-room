using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthLightScript : MonoBehaviour
{
	bool inside = false;

	void Start()
	{
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "FourthLight")
		{
			col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0);
			GameObject.Find("SpotLight_4").GetComponent<Light>().enabled = true;
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "FourthLight")
		{
			inside = !inside;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLightScript : MonoBehaviour
{

	bool inside = false;

	void Start()
	{
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "ThirdLight")
		{
			col.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1);
			GameObject.Find("SpotLight_3").GetComponent<Light>().enabled = true;
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "ThirdLight")
		{
			inside = !inside;
		}
	}
}

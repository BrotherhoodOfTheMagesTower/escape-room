using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FirstLightScript : MonoBehaviour
{
	bool inside = false;

	void Start()
	{
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "FirstLight")
		{
			col.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
			GameObject.Find("SpotLight_1").GetComponent<Light>().enabled = true;
			inside = !inside;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "FirstLight")
		{
			inside = !inside;
		}
	}

}


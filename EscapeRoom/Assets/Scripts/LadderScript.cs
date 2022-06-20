using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LadderScript : MonoBehaviour
{
	public GameObject chController;
	bool inside = false;
	public float speedUpDown = 0.5f;
		
	void Start()
	{
		chController = GameObject.Find("PlayerCapsule");
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			inside = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			inside = false;
		}
	}

	void Update()
	{
		if (inside == true && Input.GetKey(KeyCode.W))
		{
			chController.transform.position += (new Vector3(0, speedUpDown, 0));
		}

		if (inside == true && Input.GetKey(KeyCode.S))
		{
			chController.transform.position += (new Vector3(0, -speedUpDown, 0));
		}
	}
}

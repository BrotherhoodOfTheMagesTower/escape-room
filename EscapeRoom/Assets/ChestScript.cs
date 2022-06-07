using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
	bool inside = false;
	GameObject notebook;
	BoxCollider collider;
	GameObject lid;

	void Start()
	{
		inside = false;
		notebook = GameObject.FindWithTag("NotePad");
		collider = notebook.GetComponent<BoxCollider>();
		lid = GameObject.FindWithTag("ChestLid");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Chest")
		{
			collider.isTrigger = true;
			inside = !inside;
			Destroy(gameObject);
			Destroy(lid);
		}
	}
}

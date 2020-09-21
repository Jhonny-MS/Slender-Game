using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour {


	bool flashLightRequest;
	private GameObject aux;

	void Start () 
	{		
		flashLightRequest = false;
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player")
		{
			
			if (Input.GetKeyDown(KeyCode.E))
			{
				aux = coll.gameObject;
				flashLightRequest = true;
			}
		}
	}


	void Update ()
	{
		if (flashLightRequest) {
			aux.GetComponentInChildren<FlashLightManager> ().PegarLanterna ();
			Destroy (this.gameObject);
		}
	
		
	}
}

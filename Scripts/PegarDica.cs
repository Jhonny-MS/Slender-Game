using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarDica : MonoBehaviour {


	private GameObject aux;

	public void HabilitarCorAmarela ()
	{
		transform.GetChild (0).gameObject.SetActive (true);
	}
	public void DesabilitarCorAmarela ()
	{
		transform.GetChild (0).gameObject.SetActive (false);
	}



	void Start () 
	{
		aux = GameObject.Find ("GameController");
		DesabilitarCorAmarela ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player") {
			HabilitarCorAmarela ();
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Player") {
			DesabilitarCorAmarela ();
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				aux.GetComponent<GameController> ().AddDicas ();
				Destroy (this.gameObject);
			}
		}
	}

	void Update () {
		
	}
}

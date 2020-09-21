using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

	public Text voceMorreu;
	public Text subtitulo;

	public Image damageImage;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public float flashSpeed = 5f;

	private GameObject aux;
	private GameObject aux2;

	public void IsDamagedImage(){
		damageImage.color = flashColour;
	}
	public void IsNotDamagedImage(){
		damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
	}

	public void PressioneParaReiniciar()
	{
		if (Input.anyKeyDown) {
			SceneManager.LoadScene ("Slender");
		}
	}

	public void HabitarTextoGameOver(){
		voceMorreu.enabled = true;
		subtitulo.enabled = true;
	}
	public void DesabilitarTextoGameOver(){
		voceMorreu.enabled = false;
		subtitulo.enabled = false;
	}
	public void ChamarCanvasGameOver(){
		if (aux.GetComponent<GameController> ().RetornarSeEstaVivo () == false) {
			aux2.GetComponent<CharacterController> ().enabled = false;
			HabitarTextoGameOver ();
			PressioneParaReiniciar ();
		}
	}
	void Awake (){

		aux = GameObject.Find ("GameController");
		aux2 = GameObject.FindGameObjectWithTag ("Player");

		DesabilitarTextoGameOver ();
		IsNotDamagedImage ();

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ChamarCanvasGameOver ();
	}
}

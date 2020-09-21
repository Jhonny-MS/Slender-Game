using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public float vida;
	public bool estaVivo;
	int dicasQtd;
	public int multiplicador;
	public GameObject boteDeFuga;
	public GameObject jogarNovamente, sair, voceConseguiu, ajudaBote;





	public void AddDicas()
	{

		dicasQtd = dicasQtd + 1;

	}

	public void TomarDanoInimigo()
	{
		
		vida = vida - multiplicador * Time.deltaTime;
	}
	public void Checar(){
		if (vida <= 0f) {
			estaVivo = false;
		}
	}
	public bool RetornarSeEstaVivo()
	{
		return this.estaVivo;
	}
	public void FugaAutorizada()
	{
		if (dicasQtd == 7) {
			Instantiate (boteDeFuga, new Vector3 (64.46f, 1.5f, 12.63f), Quaternion.identity);
			ajudaBote.transform.GetChild (5).gameObject.SetActive (true);
			dicasQtd = 8;
		}

	}
	void FecharJogo()
	{
		Application.Quit ();
	}
	public void CarregarCenaDoJogo()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("Slender");
	}

	void Awake()
	{
		
		jogarNovamente = GameObject.Find ("Canvas");
		jogarNovamente.transform.GetChild (4).gameObject.gameObject.SetActive (false);

		ajudaBote = GameObject.Find ("Canvas");
		ajudaBote.transform.GetChild (5).gameObject.gameObject.SetActive (false);

		sair = GameObject.Find ("Canvas");
		sair.transform.GetChild (3).gameObject.gameObject.SetActive (false);

		voceConseguiu = GameObject.Find ("Canvas");
		voceConseguiu.transform.GetChild (2).gameObject.gameObject.SetActive (false);

	}

			
		
	void Start () 
	{
		vida = 100;
		estaVivo = true;
		dicasQtd = 0;
	}
	

	void Update () 
	{
		Checar ();
		FugaAutorizada ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteracaoBote : MonoBehaviour {
    private GameObject jogarNovamente,sair,voceConseguiu;//4,3,2

    void Awake()
    {
        jogarNovamente = GameObject.Find("Canvas");

        sair = GameObject.Find("Canvas");

        voceConseguiu = GameObject.Find("Canvas");

    }

    void OnTriggerStay(Collider coll)
    {
        if(coll.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0.0f;
                jogarNovamente.transform.GetChild(4).gameObject.SetActive(true);
                sair.transform.GetChild(3).gameObject.SetActive(true);
                voceConseguiu.transform.GetChild(2).gameObject.SetActive(true);
                voceConseguiu.transform.GetChild(1).gameObject.SetActive(false);
                voceConseguiu.transform.GetChild(5).gameObject.SetActive(false);
                voceConseguiu.transform.GetChild(6).gameObject.SetActive(false);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DAI

public class FlashLightManager : MonoBehaviour
{
    bool estaLigada;
    bool temLanterna;

    void Awake()
    {
        this.gameObject.GetComponentInChildren<Light>().enabled = false;
    }

    public void PegarLanterna()
    {
        temLanterna = true;
        estaLigada = true;
        this.gameObject.GetComponentInChildren<Light>().enabled = true;
    }

    public void LigarEDesligarLanterna()
    {
        if (temLanterna && estaLigada)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                estaLigada = false;
                this.gameObject.GetComponentInChildren<Light>().enabled = false;
            }
        }
        else if (temLanterna && !estaLigada)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                estaLigada = true;
                this.gameObject.GetComponentInChildren<Light>().enabled = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LigarEDesligarLanterna();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemycontroller : MonoBehaviour
{

    private GameObject player;
    NavMeshAgent agent;
    public float tempoParaTeleport;
    bool podeTeleportar;
    public GameObject gameC;
    private Animator anim;
    public bool estaTomandoDano;
    private GameObject canvas;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        podeTeleportar = true;
        anim = GetComponentInChildren<Animator>();

        canvas = GameObject.Find("Canvas");

        estaTomandoDano = false;
    }

    public void ChasePlayer()
    {
        Transform aux = player.GetComponent<Transform>();
        float dist = Vector3.Distance(aux.position, transform.position);

        if (dist <= 3.0f)
        {
            agent.enabled = false;
            anim.SetInteger("estado", 1);
        }
        else
        {
            agent.enabled = true;
            anim.SetInteger("estado", 1);
            agent.destination = player.transform.position;
        }
    }

    public void Teleportar()
    {
        if (podeTeleportar)
        {
            podeTeleportar = false;
            this.gameObject.transform.position = new Vector3(player.transform.position.x - 10,
                transform.position.y,
                player.transform.position.z - 10);//setar a position para proximo do player
            anim.SetInteger("estado", 0);
        }

        else
        {
            StartCoroutine(CoolDownTeleport());
            anim.SetInteger("estado", 0);
        }
    }

    IEnumerator CoolDownTeleport()
    {
        yield return new WaitForSeconds(tempoParaTeleport);
        podeTeleportar = true;
    }
    void PararDeAtacar()
    {
        if (gameC.GetComponent<GameController>().vida <= 0)
        {
            anim.SetInteger("estado", 0);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform aux = player.GetComponent<Transform>();
        float dist = Vector3.Distance(aux.position, transform.position);

        if (dist >= 60.3f)
        {
            Teleportar();
            estaTomandoDano = false;
        }

        else if (dist <= 30.0f)
        {
            ChasePlayer();
            estaTomandoDano = false;
        }

        if (dist <= 7.0f)
        {
            gameC.gameObject.GetComponent<GameController>().TomarDanoInimigo();
            anim.SetInteger("estado", 2);
            estaTomandoDano = true;
        }

        PararDeAtacar();

        if (estaTomandoDano)
        {
            canvas.GetComponent<CanvasController>().IsDamagedImage();
        }
        else
        {
            canvas.GetComponent<CanvasController>().IsNotDamagedImage();
        }
    }
}

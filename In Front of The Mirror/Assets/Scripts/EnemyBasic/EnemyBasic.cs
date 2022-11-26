using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBasic : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public RangoDeVision rango;

    public NavMeshAgent agente;
    public float distancia_ataque;
    public float radio_vision;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radio_vision)
        {
            agente.enabled = false;
            ani.SetBool("Run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("Walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("Walk", true);

                    break;
            }
        }
        else
        {
            var lookpos = target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);

            //NAVMESH

            agente.enabled = true;
            agente.SetDestination(target.transform.position);

            if(Vector3.Distance(transform.position, target.transform.position) > distancia_ataque && !atacando)
            {
                ani.SetBool("Walk", false);
                ani.SetBool("Run", true);
            }
            else
            {
                if (!atacando)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    ani.SetBool("Walk", false);
                    ani.SetBool("Run", false);
                }
            }
            //OLD

            /*
            if ( Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("Walk", false);
                ani.SetBool("Run", true);

                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                ani.SetBool("attack", false);

            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("Walk", false);
                ani.SetBool("run", false);

                //ani.SetBool("attack", true);
                //atacando = true;
            }
            */

        }
        if (atacando)
        {
            agente.enabled = false;
        }
        
    }


    public void Final_Ani()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > distancia_ataque + 0.2f)
        {
            ani.SetBool("attack", false);
        }
        atacando = false;
        rango.GetComponent<CapsuleCollider>().enabled = true;
    }
}

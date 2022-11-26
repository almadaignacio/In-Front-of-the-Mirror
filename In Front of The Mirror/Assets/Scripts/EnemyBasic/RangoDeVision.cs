using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDeVision : MonoBehaviour
{
    public Animator ani;
    public EnemyBasic Enemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ;

        ani.SetBool("Run", false);
        ani.SetBool("Walk", false);
        ani.SetBool("attack", true);
        Enemigo.atacando = true;
        GetComponent<CapsuleCollider>().enabled = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lintern : MonoBehaviour
{
    public Light LuzLinterna;
    public bool activLight;
    //public bool LanternInHand;
    public float cantBattery = 100f;
    public float perdidaBateria = 0.5f;

    [Header("Visuales")]
    public Image pila1;
    public Image pila2;
    public Image pila3;
    public Image pila4;
    public Sprite PilaLlena;
    public Sprite PilaVacia;
    public Text Porcentaje;

    // Start is called before the first frame update
    void Start()
    {
        LuzLinterna.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cantBattery = Mathf.Clamp(cantBattery, 0, 100); 
        int valorBateria = (int)cantBattery;
        Porcentaje.text = valorBateria.ToString() + "%";

        if (Input.GetKeyDown(KeyCode.F))
        {
            activLight = !activLight;

            if (activLight == true)
            {
                LuzLinterna.enabled = true;
            }

            if (activLight == false)
            {
                LuzLinterna.enabled = false;
            }
        }

        if (activLight == true && cantBattery > 0)
        {
            cantBattery -= perdidaBateria + Time.deltaTime;
        }

        

        

        

        if(cantBattery > 50 && cantBattery <= 75)
        {

            pila3.sprite = PilaLlena;
            pila4.sprite = PilaVacia;
            LuzLinterna.intensity = 1.5f;
        }

        if(cantBattery > 75 && cantBattery <= 100)
        {
            pila4.sprite = PilaLlena;
            LuzLinterna.intensity = 2f;
        }

        if (cantBattery > 25 && cantBattery <= 50)
        {
            pila2.sprite = PilaLlena;
            pila3.sprite = PilaVacia;

            LuzLinterna.intensity = 1f;
        }

        if (cantBattery > 0 && cantBattery <= 25)
        {
            pila1.sprite = PilaLlena;
            pila2.sprite = PilaVacia;
            LuzLinterna.intensity = 0.5f;
        }

        if (cantBattery == 0)
        {
            pila1.sprite = PilaVacia;
            LuzLinterna.intensity = 0f;
        }
    }
}

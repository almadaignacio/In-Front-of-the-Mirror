using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject SelectedBattery;
    public GameObject PressThebButton;
    public GameObject Lintern;
    public float battery;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PressThebButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Lintern.GetComponent<Lintern>().cantBattery += battery;
                //Destroy(SelectedBattery.gameObject);
                PressThebButton.SetActive(false);
                SelectedBattery.SetActive(false);
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PressThebButton.SetActive(false);
        }
    }
}

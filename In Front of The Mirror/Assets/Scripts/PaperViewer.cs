using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperViewer : MonoBehaviour
{
    private bool reading;
    public GameObject SelectedPaper;


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
            if (Input.GetKeyDown(KeyCode.E))
            {
                reading = !reading;
                if (reading == false)
                {
                    SelectedPaper.SetActive(true);
                }

                if (reading == true)
                {
                    SelectedPaper.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SelectedPaper.SetActive(false);
        }
    }
}
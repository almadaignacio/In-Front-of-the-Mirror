using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using Unity.UI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector3 direction = new Vector3(0f, 0f, 1f);
    public float Speed = 6f;
    public float cameraAxisX = 0f;
    public float SpeedRotation = 200.0f, Sensitivity = 70f;
    public float x, y;

    private Vector3 playerDirection;

    private int puntuacion = 0;

    private int Level = 2;

    CharacterController character;
    Rigidbody rb;
    Vector3 moveVector;
    Transform Cam;
    float yRotation;


    private int vida;

    public GameObject  Verde;
    public GameObject amarillo;
    public GameObject naranja;
    public GameObject rojo;

    public GameObject[] BarraVida;


    //public TMP_Text TextoContador;

    // Start is called before the first frame update
    void Start()
    {
        vida = BarraVida.Length;

        /*
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Cam = Camera.main.GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked; // freeze cursor on screen centre
        Cursor.visible = false; // invisible cursor
        */
    }

    // Update is called once per frameasd
    void Update()
    {
        /*

        RotatePlayer();
        FixedUpdate();

        float xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        float ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
        transform.Rotate(Vector3.up * xmouse);
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        Cam.localRotation = Quaternion.Euler(yRotation, 0, 0);
        */


        bool forward = Input.GetKeyDown(KeyCode.W);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        //Es posible simplificar la notación del if si el bloque contiene una única línea.

        //Limpiamos la dirección de movimiento en cada frame.
        playerDirection = Vector3.zero;
        //Elegimos una dirección en función de la tecla que se mantiene presionada.
        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;
        //Nos movemos solo si hay una dirección diferente que vector zero.
        if (playerDirection != Vector3.zero) MovePlayer(playerDirection);

        // int ValourBullet = GetComponent<Shooting>().KillCount;

        /*
        if (puntuacion == 3 && ValourBullet == 4)
        {
            SceneManager.LoadScene(Level);
        }
        */

        if (vida >= 4)
        {
           

            BarraVida[0].SetActive(true);
            BarraVida[1].SetActive(false);
            BarraVida[2].SetActive(false);
            BarraVida[3].SetActive(false);

        }

        if (vida < 4)
        {
            

            BarraVida[0].SetActive(false);
            BarraVida[1].SetActive(true);
            BarraVida[2].SetActive(false);
            BarraVida[3].SetActive(false);

        }

        if (vida < 3)
        {
            
            BarraVida[0].SetActive(false);
            BarraVida[1].SetActive(false);
            BarraVida[2].SetActive(true);
            BarraVida[3].SetActive(false);

        }

        if (vida < 2)
        {
            BarraVida[0].SetActive(false);
            BarraVida[1].SetActive(false);
            BarraVida[2].SetActive(false);
            BarraVida[3].SetActive(true);

        }

        if (vida < 1)
         {
            SceneManager.LoadScene("You Died");
        }
    }
    
    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arma"))
        {
            vida--;
        }

        if(other.CompareTag("Win"))
        {
            SceneManager.LoadScene("The end");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Healing"))
        {
            Destroy(collision.gameObject);
            vida++;
        }
    }

    /*

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // body moving
        moveVector = transform.forward * Speed * Input.GetAxis("Vertical") +
            transform.right * Speed * Input.GetAxis("Horizontal") +
            transform.up * rb.velocity.y;
        rb.velocity = moveVector;
    }
    */

    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Powerups"))
        {
            Destroy(other.gameObject);
            puntuacion = puntuacion + 1;
            TextoContador.text = puntuacion.ToString();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(3);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    */
}

using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody do xogador.
    private Rigidbody rb; 

    // Variable para levar a conta dos obxectos "PickUp" recollidos.
    private int count;

    // Movemento ao longo dos eixes X e Y.
    private float movementX;
    private float movementY;

    // Velocidade á que se move o xogador.
    public float speed = 0;

    // Compoñente de texto UI para mostrar a conta dos obxectos "PickUp" recollidos.
    public TextMeshProUGUI countText;

    // Obxecto UI para mostrar o texto de gañar.
    public GameObject winTextObject;

    // Clip de audio para reproducir ao recoller un "PickUp".
    public AudioClip pickupSound;

    // AudioSource para reproducir sons.
    private AudioSource audioSource;

    // Start é chamado antes da primeira actualización do frame.
    void Start()
    {
        // Obter e almacenar o compoñente Rigidbody adxunto ao xogador.
        rb = GetComponent<Rigidbody>();

        // Inicializar a conta a cero.
        count = 0;

        // Actualizar a visualización da conta.
        SetCountText();

        // Inicialmente establecer o texto de gañar como inactivo.
        winTextObject.SetActive(false);

        // Engadir un compoñente AudioSource se non existe xa.
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Evitar reproducir calquera son ao comezo.
    }
 
    // Esta función é chamada cando se detecta unha entrada de movemento.
    void OnMove(InputValue movementValue)
    {
        // Converter o valor de entrada nun Vector2 para o movemento.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Almacenar os compoñentes X e Y do movemento.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    // FixedUpdate é chamado unha vez por cada frame de taxa de cadros fixa.
    private void FixedUpdate() 
    {
        // Crear un vector de movemento 3D usando as entradas X e Y.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        // Aplicar forza ao Rigidbody para mover o xogador.
        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other) 
    {
        // Comprobar se o obxecto co que o xogador colidiu ten a etiqueta "PickUp".
        if (other.gameObject.CompareTag("PickUp")) 
        {
            // Desactivar o obxecto co que colidiu (facéndoo desaparecer).
            other.gameObject.SetActive(false);

            // Incrementar a conta dos obxectos "PickUp" recollidos.
            count = count + 1;

            // Reproducir o son de recollida.
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            // Actualizar a visualización da conta.
            SetCountText();
        }
    }

    // Función para actualizar a visualización da conta dos obxectos "PickUp" recollidos.
    void SetCountText() 
    {
        // Actualizar o texto da conta coa conta actual.
        countText.text = "Conta: " + count.ToString();

        // Comprobar se a conta alcanzou ou superou a condición de gañar.
        if (count >= 12)
        {
            // Mostrar o texto de gañar.
            winTextObject.SetActive(true);

            // Destruir o obxecto GameObject do inimigo.
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruir o obxecto actual
            Destroy(gameObject); 
     
            // Actualizar o winText para mostrar "Perdiches!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Perdiches!";
        }
    }
}
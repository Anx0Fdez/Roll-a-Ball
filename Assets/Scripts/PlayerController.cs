using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody del jugador.
    private Rigidbody rb; 

    // Variable para llevar la cuenta de los objetos "PickUp" recogidos.
    private int count;

    // Componente de texto UI para mostrar la cuenta de los objetos "PickUp" recogidos.
    public TextMeshProUGUI countText;

    // Objeto UI para mostrar el texto de ganar.
    public GameObject winTextObject;

    // Clip de audio para reproducir al recoger un "PickUp".
    public AudioClip pickupSound;

    // AudioSource para reproducir sonidos.
    private AudioSource audioSource;

    // Start es llamado antes de la primera actualización del frame.
    void Start()
    {
        // Obtener y almacenar el componente Rigidbody adjunto al jugador.
        rb = GetComponent<Rigidbody>();

        // Inicializar la cuenta a cero.
        count = 0;

        // Actualizar la visualización de la cuenta.
        SetCountText();

        // Inicialmente establecer el texto de ganar como inactivo.
        winTextObject.SetActive(false);

        // Añadir un componente AudioSource si no existe ya.
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Evitar reproducir cualquier sonido al comienzo.
    }

    void OnTriggerEnter(Collider other) 
    {
        // Comprobar si el objeto con el que el jugador colisionó tiene la etiqueta "PickUp".
        if (other.gameObject.CompareTag("PickUp")) 
        {
            // Desactivar el objeto con el que colisionó (haciéndolo desaparecer).
            other.gameObject.SetActive(false);

            // Incrementar la cuenta de los objetos "PickUp" recogidos.
            count = count + 1;

            // Reproducir el sonido de recogida.
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            // Actualizar la visualización de la cuenta.
            SetCountText();
        }
    }

    // Función para actualizar la visualización de la cuenta de los objetos "PickUp" recogidos.
    void SetCountText() 
    {
        // Actualizar el texto de la cuenta con la cuenta actual.
        countText.text = "Cuenta: " + count.ToString();

        // Comprobar si la cuenta alcanzó o superó la condición de ganar.
        if (count >= 12)
        {
            // Mostrar el texto de ganar.
            winTextObject.SetActive(true);

            // Destruir el objeto GameObject del enemigo.
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruir el objeto actual
            Destroy(gameObject); 
     
            // Actualizar el winText para mostrar "¡Perdiste!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "¡Perdiste!";
        }
    }
}
using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento de la bola
    public float boostForce = 20f; // Fuerza para el boost
    private Rigidbody rb; // Referencia al componente Rigidbody
    private bool isBoosted = false; // Indica si el boost está activo

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody al iniciar
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // Obtiene el input horizontal (A/D o flechas izquierda/derecha)
        float moveY = Input.GetAxis("Vertical"); // Obtiene el input vertical (W/S o flechas arriba/abajo)

        Vector3 movement = new Vector3(moveX, 0, moveY) * speed; // Crea un vector de movimiento basado en el input y la velocidad
        rb.AddForce(movement); // Aplica la fuerza de movimiento al Rigidbody
    }

    public void ApplyBoost(float multiplier, float duration)
    {
        if (!isBoosted) // Si el boost no está activo
        {
            StartCoroutine(BoostCoroutine(multiplier, duration)); // Inicia la corrutina de boost
        }
    }

    private IEnumerator BoostCoroutine(float multiplier, float duration)
    {
        isBoosted = true; // Marca el boost como activo
        rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse); // Aplica una fuerza extra en la dirección del movimiento actual

        yield return new WaitForSeconds(duration); // Espera la duración del boost

        isBoosted = false; // Marca el boost como inactivo
    }
}
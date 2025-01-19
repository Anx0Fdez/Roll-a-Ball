using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Variable para almacenar el componente Rigidbody (física) del objeto
    
    // Variables para almacenar el movimiento en los ejes X e Y
    private float movementX;
    private float movementY;
    
    public float speed = 0; // Velocidad de movimiento


    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // GetComponent es un método que obtiene un componente de un objeto
    }

    // FixedUpdate se llama en intervalos fijos de tiempo, ideal para la física
    private void FixedUpdate()
    {
        // Creamos un vector de movimiento usando las variables de movimiento en X e Y
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        // Aplicamos una fuerza al Rigidbody en la dirección del vector de movimiento multiplicado por la velocidad para mover al jugador
        rb.AddForce(movement * speed);
    }

    // Método que se llama cuando se detecta movimiento de entrada
    void OnMove(InputValue movementValue)
    {
        // Obtenemos el vector de movimiento de la entrada del jugador
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Asignamos los valores del vector de movimiento a nuestras variables de movimiento
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}

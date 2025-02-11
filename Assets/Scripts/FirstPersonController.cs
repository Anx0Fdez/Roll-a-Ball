using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la cámara

    void Update()
    {
        MoveAndRotateCamera(); // Llama al método para mover y rotar la cámara en cada frame
    }

    void MoveAndRotateCamera()
    {
        float moveX = 0f; // Inicializa la variable para el movimiento en el eje X
        float moveZ = 0f; // Inicializa la variable para el movimiento en el eje Z

        // Si se presiona la tecla de flecha arriba, mover hacia adelante
        if (Keyboard.current.upArrowKey.isPressed) moveZ = 1f; 
        // Si se presiona la tecla de flecha abajo, mover hacia atrás
        if (Keyboard.current.downArrowKey.isPressed) moveZ = -1f; 
        // Si se presiona la tecla de flecha derecha, mover hacia la derecha
        if (Keyboard.current.rightArrowKey.isPressed) moveX = 1f; 
        // Si se presiona la tecla de flecha izquierda, mover hacia la izquierda
        if (Keyboard.current.leftArrowKey.isPressed) moveX = -1f; 

        // Crea un vector de movimiento basado en las entradas del teclado
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ); 

        if (moveDirection != Vector3.zero) // Si hay movimiento
        {
            // Ajustar la rotación de la cámara para que mire en la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // Interpola suavemente hacia la nueva rotación
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); 
        }

        // Actualiza la posición de la cámara en la dirección del movimiento, normalizando la dirección y aplicando la velocidad y el tiempo
        transform.position += moveDirection.normalized * (moveSpeed * 0.5f) * Time.deltaTime; 
    }
}
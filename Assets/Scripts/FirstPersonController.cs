using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movemento da cámara

    void Update()
    {
        // Mover a cámara e axustala segundo a dirección do xogador
        MoveAndRotateCamera();
    }

    void MoveAndRotateCamera()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Detectar as teclas de movemento (frechas)
        if (Keyboard.current.upArrowKey.isPressed) moveZ = 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveZ = -1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX = 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX = -1f;

        // Calcular a dirección de movemento
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);

        if (moveDirection != Vector3.zero)
        {
            // Axustar a rotación da cámara para que mire na dirección do movemento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection); // Quaternion é unha estrutura que representa unha rotación en 3D e serve para almacenar e manipular rotacións
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Nesta liña, interpólase entre a rotación actual e a rotación obxectivo para que a transición sexa suave
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour 
{
    public Camera[] cameras; // Array de cámaras configuradas en el Inspector
    private int currentCameraIndex = 0; // Índice de la cámara activa

    void Start()
    {
        ActivateCamera(currentCameraIndex); // Activar la cámara inicial
    }

    void Update()
    {
        // Detecta si se presiona la tecla "C"
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // Desactiva la cámara actual
        cameras[currentCameraIndex].enabled = false;

        // Cambia al siguiente índice (ciclo circular)
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Activa la nueva cámara
        ActivateCamera(currentCameraIndex);
    }

    void ActivateCamera(int index)
    {
        // Activa solo la cámara especificada
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = i == index;
        }
    }
}
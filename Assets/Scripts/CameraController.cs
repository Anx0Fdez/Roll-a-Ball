using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Esto es un GameObject llamado player que sirve para guardar el objeto que queremos seguir
    private Vector3 offset; // Esto es un Vector3 llamado offset que sirve para guardar la distancia entre la cámara y el objeto que queremos seguir
    
    // Start es llamado antes de la primera actualización del frame
    void Start()
    {
        offset = transform.position - player.transform.position; // Calculamos la distancia entre la cámara y el objeto que queremos seguir
    }

    // LateUpdate es llamado una vez por cada frame, después de que todos los Update hayan sido llamados
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Actualizamos la posición de la cámara para que siga al objeto que queremos seguir
    }
}
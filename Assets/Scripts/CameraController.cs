using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player; // Isto é un GameObject que se chama player que serve para gardar o obxecto que queremos seguir
    private Vector3 offset; // Isto é un Vector3 que se chama offset que serve para gardar a distancia entre a cámara e o obxecto que queremos seguir
    
    // Start é chamado antes da primeira actualización do frame
    void Start()
    {
        offset = transform.position - player.transform.position; // Calculamos a distancia entre a cámara e o obxecto que queremos seguir
    }

    // Update é chamado unha vez por cada frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Actualizamos a posición da cámara para que siga ao obxecto que queremos seguir
    }
}
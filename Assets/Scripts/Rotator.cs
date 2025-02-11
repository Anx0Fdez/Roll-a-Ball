using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update es llamado una vez por cada frame
    void Update()
    {
        // Rotar el objeto en los ejes X, Y y Z por cantidades especificadas, ajustadas para la tasa de cuadros.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
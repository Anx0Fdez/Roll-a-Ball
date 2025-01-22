using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update é chamado unha vez por cada frame
    void Update()
    {
        // Rotar o obxecto nos eixes X, Y e Z por cantidades especificadas, axustadas para a taxa de cadros.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

}
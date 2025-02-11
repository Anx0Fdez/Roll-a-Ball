using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostForce = 20f; // Ajusta la fuerza del boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que la bola tiene el tag "Player"
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Obtener la normal de la superficie de la rampa
                RaycastHit hit;
                if (Physics.Raycast(other.transform.position, Vector3.down, out hit, 2f))
                {
                    Vector3 normal = hit.normal; // Normal de la rampa
                    Vector3 playerVelocity = rb.velocity.normalized; // Dirección actual del jugador

                    // Proyectar la dirección del jugador en la normal para adaptarse a la rampa
                    Vector3 boostDirection = Vector3.ProjectOnPlane(playerVelocity, normal).normalized;

                    rb.AddForce(boostDirection * boostForce, ForceMode.Impulse);
                }
            }
        }
    }
}
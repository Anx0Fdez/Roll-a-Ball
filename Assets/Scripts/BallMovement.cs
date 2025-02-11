using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f;
    public float boostForce = 20f; // Fuerza para el boost
    private Rigidbody rb;
    private bool isBoosted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveY) * speed;
        rb.AddForce(movement);
    }

    public void ApplyBoost(float multiplier, float duration)
    {
        if (!isBoosted) 
        {
            StartCoroutine(BoostCoroutine(multiplier, duration));
        }
    }

    private IEnumerator BoostCoroutine(float multiplier, float duration)
    {
        isBoosted = true;
        rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse); // Aplica fuerza extra

        yield return new WaitForSeconds(duration);

        isBoosted = false;
    }
}
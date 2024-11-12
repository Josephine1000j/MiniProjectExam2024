using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float leanAngle = 15f; // Angle to lean left/right
    public float leanSpeed = 5f;  // Speed to smooth the lean
    public float jumpForce = 5f;  // Controlled jump force
    public SpawnManager spawnManager;

    private bool isRunning = false;
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isRunning = true;
        }

        if (isRunning)
        {
            float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
            float vMovement = movementSpeed;

            transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);

            float targetLeanAngle = Input.GetAxis("Horizontal") * leanAngle;
            Quaternion targetRotation = Quaternion.Euler(0, targetLeanAngle, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, leanSpeed * Time.deltaTime);
        }

        // Jump logic: only allow jump if grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero; // Reset any existing velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); // Apply jump force
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player lands back on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero; // Reset velocity on landing
        }
    }
}

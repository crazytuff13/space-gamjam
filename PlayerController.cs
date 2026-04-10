using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 8f;
    public float fallThreshold = -20f;

    [Header("Audio")]
    public AudioSource jumpSound;
    public AudioSource landSound;

    private Rigidbody2D rb;
    private Vector3 spawnPosition;

    private bool wasFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        rb.gravityScale = 0.85f;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (Keyboard.current == null)
            return;

        float move = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            move = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Unlimited jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (jumpSound != null)
            {
                jumpSound.pitch = Random.Range(0.97f, 1.03f);
                jumpSound.Play();
            }
        }

        // Track falling
        if (rb.linearVelocity.y < -0.1f)
            wasFalling = true;

        // Detect landing based on velocity change
        if (wasFalling && rb.linearVelocity.y >= 0f)
        {
            if (landSound != null)
            {
                landSound.pitch = Random.Range(0.97f, 1.03f);
                landSound.Play();
            }

            wasFalling = false;
        }

        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPosition;
        wasFalling = false;
    }
}

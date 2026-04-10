using UnityEngine;

public class KeyTile : MonoBehaviour
{
    public string letter;
    public Sprite unpressedSprite;
    public Sprite pressedSprite;

    [Header("Audio")]
    public AudioSource keySound;

    private SpriteRenderer spriteRenderer;
    private MyGameManager gameManager;
    private bool isPressed = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameManager = FindFirstObjectByType<MyGameManager>();

        if (unpressedSprite != null)
            spriteRenderer.sprite = unpressedSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            if (pressedSprite != null)
                spriteRenderer.sprite = pressedSprite;

            if (gameManager != null)
                gameManager.KeyPressed(letter);

            if (keySound != null)
            {
                keySound.pitch = Random.Range(0.95f, 1.05f);
                keySound.Play();
            }

            Debug.Log("Player stepped on letter: " + letter);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPressed = false;

            if (unpressedSprite != null)
                spriteRenderer.sprite = unpressedSprite;
        }
    }
}

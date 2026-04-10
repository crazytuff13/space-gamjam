using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    [Header("Scene")]
    public string nextSceneName;

    [Header("Components")]
    public SpriteRenderer portalSprite;
    public Collider2D portalCollider;

    [Header("Audio")]
    public AudioSource appearSound;
    public AudioSource enterSound;

    private bool isActivated = false;
    private bool hasEntered = false;

    void Start()
    {
        if (portalSprite != null)
            portalSprite.enabled = false;

        if (portalCollider != null)
            portalCollider.enabled = false;
    }

    public void ActivatePortal()
    {
        if (isActivated)
            return;

        isActivated = true;

        if (portalSprite != null)
            portalSprite.enabled = true;

        if (portalCollider != null)
            portalCollider.enabled = true;

        if (appearSound != null)
            appearSound.Play();

        Debug.Log("Portal fully enabled.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated || hasEntered)
            return;

        if (other.CompareTag("Player"))
        {
            hasEntered = true;

            if (enterSound != null)
                enterSound.Play();

            Invoke(nameof(LoadNextScene), 0.5f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

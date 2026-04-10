using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class QuickInput : MonoBehaviour
{
    [Header("Scene Names")]
    public string menuScene = "Menu";          // Your actual menu scene
    public string gameplayScene = "SampleScene"; // Your main gameplay scene

    void Update()
    {
        if (Keyboard.current == null)
            return;

        // ESC → Go to Menu
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(menuScene);
        }

        // R → Restart gameplay scene
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(gameplayScene);
        }
    }
}

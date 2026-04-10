using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject controlPanel;
    public GameObject mainButtons;

    // START GAME
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // EXIT GAME
    public void ExitGame()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // OPEN CONTROLS PANEL
    public void OpenControls()
    {
        if (controlPanel != null)
            controlPanel.SetActive(true);

        if (mainButtons != null)
            mainButtons.SetActive(false);
    }

    // CLOSE CONTROLS PANEL
    public void CloseControls()
    {
        if (controlPanel != null)
            controlPanel.SetActive(false);

        if (mainButtons != null)
            mainButtons.SetActive(true);
    }
}

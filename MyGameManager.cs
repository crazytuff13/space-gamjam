using UnityEngine;
using TMPro;

public class MyGameManager : MonoBehaviour
{
    [Header("Word Puzzle")]
    public string targetWord = "SPACE";
    private int currentIndex = 0;
    private bool wordCompleted = false;

    [Header("UI")]
    public TextMeshProUGUI wordDisplay;

    [Header("Portal")]
    public GameObject exitPortal;

    void Start()
    {
        UpdateWordDisplay();

        if (exitPortal != null)
            exitPortal.SetActive(false);
    }

    public void KeyPressed(string letter)
    {
        if (wordCompleted) return;

        if (letter == targetWord[currentIndex].ToString())
        {
            currentIndex++;

            if (currentIndex >= targetWord.Length)
            {
                WordCompleted();
            }
        }
        else
        {
            currentIndex = 0;
        }

        UpdateWordDisplay();
    }

    void WordCompleted()
    {
        wordCompleted = true;
        Debug.Log("WORD COMPLETE!");

        if (exitPortal != null)
        {
            exitPortal.SetActive(true);

            PortalTrigger portalScript = exitPortal.GetComponent<PortalTrigger>();
            if (portalScript != null)
            {
                portalScript.ActivatePortal();
            }
        }
    }

    void UpdateWordDisplay()
    {
        string display = "";

        for (int i = 0; i < targetWord.Length; i++)
        {
            if (i < currentIndex)
                display += targetWord[i] + " ";
            else
                display += "_ ";
        }

        if (wordDisplay != null)
            wordDisplay.text = display;
    }
}

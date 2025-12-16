using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public GameObject InstructionsPanel;
    public GameObject StoryPanel;

    void Start()
    {
        InstructionsPanel.SetActive(false);
        StoryPanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Instructions()
    {
        InstructionsPanel.SetActive(true);
    }

    public void InstructionsExit()
    {

        InstructionsPanel.SetActive(false);
    }

    public void Story()
    {
        StoryPanel.SetActive(true);
    }

    public void StoryExit()
    {
        StoryPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartScreen()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void Scene(int index)
    {
        SceneManager.LoadScene(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtons : MonoBehaviour
{
    public void Menu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Play");
    }

    public void Help()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Help");
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

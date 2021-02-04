using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Button JoinButton;

    //Add here the way to join the ui
    public void PlayButton()
    {
        JoinButton.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //it loads the next scene
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}

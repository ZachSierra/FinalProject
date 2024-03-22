using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void OptionScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
}

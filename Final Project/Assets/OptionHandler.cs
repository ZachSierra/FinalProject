using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class OptionHandler : MonoBehaviour
{
    public void BackButton(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

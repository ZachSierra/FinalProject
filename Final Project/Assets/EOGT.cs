using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOGT : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        if(other.name == "MainCharacter"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}

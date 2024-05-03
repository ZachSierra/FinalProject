using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image screen;
    [SerializeField] float fadeTime = 0f;
    public void ColorTransition(Color c, string scene = ""){
        screen.color = new Color(c.r, c.g, c.b, 0);
        StartTransitionOut(scene);
    }
    public void StartTransitionOut(string newScene = ""){
        StartCoroutine(StartTransitionOutRoutine());
        IEnumerator StartTransitionOutRoutine(){
            float timer = 0;
            while( timer < fadeTime){
                yield return null;
                timer += Time.deltaTime;
                screen.color = new Color(screen.color.r, 0, 0, (timer/fadeTime));
            }
            screen.color = new Color(screen.color.r, 0, 0, 1);
            if (newScene != ""){
                UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
            }
        }
    }
}

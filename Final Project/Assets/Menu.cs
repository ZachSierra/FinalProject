using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] float fadeTime = 1f;
    [SerializeField] UnityEngine.UI.Image screen;
    void Start(){
        StartTransitionIn();
    }
    public void TransitionToMainMenu(){
        StartTransitionOut("MainMenu");
    }
    public void StartTransitionIn(){
            StartCoroutine(StartTransitionInRoutine());
            IEnumerator StartTransitionInRoutine(){
                float timer = 0;
                while( timer < fadeTime ){
                    yield return null;
                    timer += Time.deltaTime;
                    screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, fadeTime - timer);
                    
                }
                screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, 0);
            }

        }
        public void StartTransitionOut(string newScene = ""){
        StartCoroutine(StartTransitionOutRoutine());
        IEnumerator StartTransitionOutRoutine(){
            float timer = 0;
            while( timer < fadeTime){
                yield return null;
                timer += Time.deltaTime;
                screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, (timer/fadeTime));
            }
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, 1);
            if (newScene != ""){
                UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
            }
        }
    }
}

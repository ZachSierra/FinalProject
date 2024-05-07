using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOGT : MonoBehaviour
{
    [SerializeField] GameEnding gEnding;
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        if(other.name == "MainCharacter"){
            gEnding.ColorTransition(new Color(0,0,0), "GameOverGood");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        if(other.name == "MainCharacter"){
            other.GetComponent<MainCharacter>().SetAmmo(other.GetComponent<MainCharacter>().GetAmmo() + 5);
        }
        
        Destroy(gameObject);
    }
}

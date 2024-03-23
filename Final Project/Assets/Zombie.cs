using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        if(other.name == "MainCharacter"){
            other.GetComponent<MainCharacter>().SetHealth(other.GetComponent<MainCharacter>().GetHealth() - 5);
        }
        if(other.name == "Bullet(Clone)"){
            Destroy(gameObject);
        }
    }
}

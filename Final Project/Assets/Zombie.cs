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
    void OnCollisionEnter(Collision collider){
        GameObject other = collider.gameObject;
        Debug.Log(other.tag);
        if(other.name == "MainCharacter"){
            other.GetComponent<MainCharacter>().SetHealth(other.GetComponent<MainCharacter>().GetHealth() - 5);
        }
    }
}

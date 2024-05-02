using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int maxAmt = 30;
    
    [SerializeField] float minSpawnRangeX;
    [SerializeField] float maxSpawnRangeX;
    [SerializeField] float minSpawnRangeY;
    [SerializeField] float maxSpawnRangeY;
    // Start is called before the first frame update
    void Start(){
        
        SpawnAmmo();

    }
    void FixedUpdate()
    {
        
    }

    void SpawnAmmo(){
        for ( int i = 0; i < maxAmt; i++){
            SpawnAmmoRandom();
        }
    }




    public void SpawnAmmoRandom(){

       float randomX = Random.Range(minSpawnRangeX,maxSpawnRangeX);
       float randomY = Random.Range(minSpawnRangeY,maxSpawnRangeY);

       GameObject newAmmo = Instantiate(objectPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);
       newAmmo.transform.eulerAngles = new Vector3(0,0,0);
    }
}

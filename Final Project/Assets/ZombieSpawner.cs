using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    [SerializeField] public List<Creature> zombies = new List<Creature> ();
    [SerializeField] float minSpawnRangeX;
    [SerializeField] float maxSpawnRangeX;
    [SerializeField] float minSpawnRangeY;
    [SerializeField] float maxSpawnRangeY;
    // Start is called before the first frame update
    void Start(){
        
        SpawnZombie();

    }

    void SpawnZombie(){
        for ( int i = 0; i < zombies.Count; i++){
            SpawnZombieRandom(zombies[i]);
        }
    }




    public void SpawnZombieRandom(Creature zombie){

       float randomX = Random.Range(minSpawnRangeX,maxSpawnRangeX);
       float randomY = Random.Range(minSpawnRangeY,maxSpawnRangeY);

       zombie.transform.position = new Vector3(randomX, randomY, 0);

       //GameObject newAmmo = Instantiate(objectPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);
       //objects.Add(newAmmo);
       //newAmmo.transform.eulerAngles = new Vector3(0,0,0);
    }
}

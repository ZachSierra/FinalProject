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
        RaycastHit hit;
        float randomX;
        float randomY;
        int times = 0;
        do{
            randomX = Random.Range(minSpawnRangeX,maxSpawnRangeX);
            randomY = Random.Range(minSpawnRangeY,maxSpawnRangeY);
            if(times > 3){
                break;
            }
            times++;

        }while(!Physics.SphereCast(new Vector3(randomX, randomY, 0), 0.08f, new Vector3(0, 0, 0), out hit, 1f, 0));


        zombie.transform.position = new Vector3(randomX, randomY, 0);



       //GameObject newAmmo = Instantiate(objectPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);
       //objects.Add(newAmmo);
       //newAmmo.transform.eulerAngles = new Vector3(0,0,0);
    }
}

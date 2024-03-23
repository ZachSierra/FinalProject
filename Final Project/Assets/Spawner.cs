using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] float minSpawnRangeX;
    [SerializeField] float maxSpawnRangeX;
    [SerializeField] float minSpawnRangeY;
    [SerializeField] float maxSpawnRangeY;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAmmo();
    }

    void SpawnAmmo(){
        StartCoroutine(SpawnAmmoRoutine());
        IEnumerator SpawnAmmoRoutine(){
            while(true){
                yield return new WaitForSeconds(50);
                SpawnAmmoRandom();
                SpawnAmmoRandom();
                SpawnAmmoRandom();
                SpawnAmmoRandom();
                SpawnAmmoRandom();
                SpawnAmmoRandom();
                SpawnAmmoRandom();
            }
        }
    }




    void SpawnAmmoRandom(){

       float randomX = Random.Range(minSpawnRangeX,maxSpawnRangeX);
       float randomY = Random.Range(minSpawnRangeY,maxSpawnRangeY);

       GameObject newAmmo = Instantiate(objectPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);
       Destroy(newAmmo,30);
       newAmmo.transform.eulerAngles = new Vector3(0,0,0);
    }
}

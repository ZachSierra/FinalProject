using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creature : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 0f;
    

    public enum CreatureMovementType { tf, physics };
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;
    public enum CreaturePerspective { topDown, sideScroll };
    [SerializeField] CreaturePerspective perspectiveType = CreaturePerspective.topDown;

    [Header("Physics")]
    [SerializeField] LayerMask groundMask;

    [Header("Flavor")]
    public GameObject body;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    Rigidbody2D rb;
    public MainCharacter newtarget;
    [SerializeField] public ZombieSpawner zSpawner;
    [SerializeField] public GameObject SFXBox;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCreature(Vector3 direction)
    {

        if (movementType == CreatureMovementType.tf)
        {
            MoveCreatureTransform(direction);
        }
        else if (movementType == CreatureMovementType.physics)
        {
            MoveCreatureRb(direction);
        }
    }

    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }

    public void Stop(){
        MoveCreature(Vector3.zero);
    }

    public void MoveCreatureRb(Vector3 direction)
    {
        Vector3 currentVelocity = Vector3.zero;
        if(perspectiveType == CreaturePerspective.sideScroll){
            currentVelocity = new Vector3(0, rb.velocity.y, 0);
            direction.y = 0;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
        
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        
        //rb.velocity = (currentVelocity) + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-10,10,10);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(10,10,10);
        }
        


        //rb.AddForce(direction * speed);
        //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void MoveCreatureTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        if(other.name == "MainCharacter"){
            other.GetComponent<MainCharacter>().SetHealth(other.GetComponent<MainCharacter>().GetHealth() - 5);
            gameObject.GetComponent<AudioSource>().Play();
        }
        
        if(other.name == "Bullet(Clone)"){
            getZombieSpawner().SpawnZombieRandom(gameObject.GetComponent<Creature>());
            
        }
    }

    public ZombieSpawner getZombieSpawner(){
        return zSpawner;
    }

    
}
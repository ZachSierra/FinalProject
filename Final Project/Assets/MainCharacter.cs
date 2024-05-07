using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainCharacter : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed = 35;
    [SerializeField] float health = 20;
    [SerializeField] float ammo = 5;
    Rigidbody2D rb;
    [SerializeField] Camera cam;
    Vector2 mousePosition;
    [SerializeField] GameEnding gEnding;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        
    }
    void FixedUpdate(){
        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (health <= 0){
            gEnding.StartTransitionOut("GameOverBad");
        }
    }

    public void Move(Vector2 movement){
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }
    public float GetAmmo(){
        return this.ammo;
    }
    public void SetAmmo(float ammo){
        this.ammo = ammo;
    }
    public float GetHealth(){
        return this.health;
    }
    public void SetHealth(float health){
        this.health = health;
    }
}

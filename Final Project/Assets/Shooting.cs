using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] MainCharacter Mc;
    [SerializeField] GameObject shootAudio;

    // Update is called once per frame
    void Update()
    {
        float CharacterAmmo = Mc.GetAmmo();
        if(Input.GetButtonDown("Fire1") && (CharacterAmmo > 0) ){
            Shoot();
            Mc.SetAmmo(CharacterAmmo -1);
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        shootAudio.GetComponent<AudioSource>().Play();
    }
}

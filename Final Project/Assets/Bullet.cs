using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.SearchService;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
    }
}

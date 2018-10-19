using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private Vector3 target;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;
    public Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {
        //rigid = 
       // target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Foe")
        {
            GameObject.Destroy(this.gameObject);
        }
        if (collision.tag == "Collider")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = (Input.mousePosition - target).normalized;
      //  rigidbody2D.AddForce(dir * amount);



    }
}
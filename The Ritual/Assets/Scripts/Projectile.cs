using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime;
    private Vector3 target;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;
    public Rigidbody2D rigid;
    public GameObject Foe1;
    public Rigidbody2D myrb;
    
    // Use this for initialization
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0.0f;
        target = target - transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "North Border" || collision.tag == "South Border" || collision.tag == "East Border" || collision.tag == "West Border" )
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myrb.velocity = target * speed;
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);



    }
   
}
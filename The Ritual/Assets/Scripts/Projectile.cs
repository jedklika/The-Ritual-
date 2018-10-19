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
    public GameObject Foe1;
    
    // Use this for initialization
    void Start()
    {
   
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0.0f;
        target = target - transform.position;
        StartCoroutine(DestroyBullet());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Foe")
        {
            GameManager.gm.Foe1.EnemyAICombat.TakeDamage(damage);
        }
        if (collision.tag == "Collider")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);



    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
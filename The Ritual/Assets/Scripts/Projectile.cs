﻿using System.Collections;
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
    // Use this for initialization
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
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime * 5);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Foe"))
            {
                Debug.Log("Foe Must Take Damage");
                hitinfo.collider.GetComponent<EnemyAICombat>().TakeDamage(damage);
            }
        }
    }
}
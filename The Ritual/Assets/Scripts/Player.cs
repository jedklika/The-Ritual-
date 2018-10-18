﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] string loadLevel;

    public BoxCollider2D col;
    public int health;
    float moveHorizontal;
    float moveVertical;
    public int speed = 5;
    public int ammoCount;
    public GameObject Projectile;
    public Transform ShotPoint;
    private float TimeBtwShot;
    public float StartTimeBtwShot;
    public float attackRange;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public int damage;
    private float timeBtwPower;
    public float startTimeBtwPower;
    public float PowerRange;


    void Start()
    {
        col = GetComponent<BoxCollider2D>();

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed));
        if (Input.GetAxis("Horizontal") < 0 )
        {
             
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
           
        }
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       // float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
       // transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        if (TimeBtwShot <= 0 && Input.GetMouseButtonDown(0) && ammoCount > 0)
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                TimeBtwShot = StartTimeBtwShot;
            }
        else
             {
            TimeBtwShot -= Time.deltaTime;
           // ammoCount -= 1;
             }
        if (Input.GetMouseButtonDown(1) && timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyAICombat>().TakeDamage(damage);

            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        /*if (Input.GetKeyDown(KeyCode.P) && Throwammocount > 0)
        {
            Instantiate(Projectile, ShotPoint.position, transform.rotation);
            timeBtwThrow = startTimeBtwThrow;
            Throwammocount -= 1;
        }
        else
        {
            timeBtwThrow -= Time.deltaTime;

        }*/
        if (Input.GetKeyDown(KeyCode.Space) && timeBtwPower <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, PowerRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyAICombat>().TakeDamage(damage);

            }
            timeBtwPower = startTimeBtwPower;
        }
        else
        {
            timeBtwPower -= Time.deltaTime;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bounds")
        {
            Debug.Log("Its hit bitch");
            GameManager.gm.LevelLoader();
           //SceneManager.LoadScene("OpeningScene");
        }

    }
}

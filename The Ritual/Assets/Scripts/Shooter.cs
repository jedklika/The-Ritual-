﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{

    public GameObject Projectile;
    public Transform ShotPoint;
    private float TimeBtwShot;
    public float StartTimeBtwShot;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        if (TimeBtwShot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                TimeBtwShot = StartTimeBtwShot;
                GameManager.gm.BulletsText.text = "Bullets: " +- GameManager.gm.ammoCount;
            }
        }
        else
        {
            TimeBtwShot -= Time.deltaTime;
        }
    }
}
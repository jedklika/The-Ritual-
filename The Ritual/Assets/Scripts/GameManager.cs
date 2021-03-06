﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public GameObject Foe;
    public static GameManager gm;
    public int ammoCount;
    public int ThrowammoCount;
    public int health;
    public int damage;
    public Text HealthText;
    public Text BulletsText;
    public Text ThrowAmmoText;
    public Canvas canvas;
    public bool haveAmmo;
    void Awake()
    {

        if (gm == null) gm = this;
        else if (gm != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);


    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }
        public void Update()
    {
        if(ammoCount > 0)
        {
            haveAmmo = true;
        }
        else
        {
            haveAmmo = false;
        }
        HealthText.text = "Health: " + health;
        BulletsText.text = "Bullets: " + ammoCount;
        ThrowAmmoText.text = "Throw ammo: " + ThrowammoCount;
    } 
    public void LevelLoader(string border)
    {
        Scene current = SceneManager.GetActiveScene();
        if (current.name == "Scene 1,1")
        {
            if(border == "North Border")
            {               
                SceneManager.LoadScene("Scene 0,1");
            }
           else if(border == "South Border")
            {
                SceneManager.LoadScene("Scene 2,1");
            }
           else if(border == "East Border")
            {
                SceneManager.LoadScene("Scene 1,2");
            }
           else if(border == "West Border")
            {
                SceneManager.LoadScene("Scene 1,0");
            }
        }
       else if (current.name == "Scene 0,0")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 2,0");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 1,0");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 0,1");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 0,2");
            }
        }
       else if (current.name == "Scene 0,1")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 2,1");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 1,1");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 0,2");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 0,0");
            }
        }
       else if (current.name == "Scene 0,2")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 2,2");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 1,2");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 0,0");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 0,1");
            }
        }
       else if (current.name == "Scene 1,0")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 0,0");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 2,0");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 1,1");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 1,2");
            }
        }
       else if (current.name == "Scene 1,2")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 0,2");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 2,2");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 1,0");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 1,1");
            }
        }
       else if (current.name == "Scene 2,0")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 1,0");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 0,0");
            }
          else  if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 2,1");
            }
          else  if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 2,2");
            }
        }
      else  if (current.name == "Scene 2,1")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 1,1");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 0,1");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 2,2");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 2,0");
            }
        }
      else  if (current.name == "Scene 2,2")
        {
            if (border == "North Border")
            {
                SceneManager.LoadScene("Scene 1,2");
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 0,2");
            }
           else if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 2,0");
            }
           else if (border == "West Border")
            {
                SceneManager.LoadScene("Scene 2,1");
            }
        }
       

    }

    
    IEnumerator SpawnEnemy()
    {
        float spawnCountdown;
        Scene current;
        while (true)
        {
            
            spawnCountdown = 10.0f;
            while(spawnCountdown > 0)
            {
                Debug.Log("Spawn Time: " + spawnCountdown);
                yield return new WaitForSeconds(1.0f);
                spawnCountdown--;
            }
            current = SceneManager.GetActiveScene();
            GameObject enemy = Instantiate(Foe, transform.position, Quaternion.identity);           
            spawnCountdown = 10.0f;
            while(spawnCountdown > 0 && current == SceneManager.GetActiveScene() )
            {
                Debug.Log("Remaining Time: " + spawnCountdown);
                yield return new WaitForSeconds(1.0f);
                spawnCountdown--;
            }
            Destroy(enemy);
        }
        
    }
}

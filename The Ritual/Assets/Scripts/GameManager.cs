using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public GameObject Foe;
    public static GameManager gm = null;
    public int ammoCount;
    public int ThrowammoCount;
    public int health;

    void Awake()
    {

        if (gm == null) gm = this;
        else if (gm != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
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
                return;
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
                return;
            }
        }
       else if (current.name == "Scene 0,1")
        {
            if (border == "North Border")
            {
                return;
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
                return;
            }
           else if (border == "South Border")
            {
                SceneManager.LoadScene("Scene 1,2");
            }
           else if (border == "East Border")
            {
                return;
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
                return;
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
                return;
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
                return;
            }
          else  if (border == "East Border")
            {
                SceneManager.LoadScene("Scene 2,1");
            }
          else  if (border == "West Border")
            {
                return;
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
                return;
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
                return;
            }
           else if (border == "East Border")
            {
                return;
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

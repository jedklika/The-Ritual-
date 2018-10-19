using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public GameObject Foe;
    public static GameManager gm = null;
    public string[,] Scenes = new string[3,3]; 

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
    public void LevelLoader()
    {

    }

    
    IEnumerator SpawnEnemy()
    {
        float spawnCountdown;
        while (true)
        {
            spawnCountdown = 10.0f;
            while(spawnCountdown > 0)
            {
                Debug.Log("Spawn Time: " + spawnCountdown);
                yield return new WaitForSeconds(1.0f);
                spawnCountdown--;
            }
            GameObject enemy = Instantiate(Foe, transform.position, Quaternion.identity);
            spawnCountdown = 10.0f;
            while(spawnCountdown > 0)
            {
                Debug.Log("Remaining Time: " + spawnCountdown);
                yield return new WaitForSeconds(1.0f);
                spawnCountdown--;
            }
            Destroy(enemy);
        }
        
    }
}

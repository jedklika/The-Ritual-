using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //[SerializeField] string loadLevel;

    public BoxCollider2D col;
    public Rigidbody2D rig;
    public int health;
    float moveHorizontal;
    float moveVertical;
    public int speed = 5;
    public int ammoCount;
    public int ThrowammoCount;
    public GameObject Projectile;
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
    private float timeBtwThrow;
    public float startTimeBtwThrow;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

    }
    public void TakeDamage(int damage)
    {
        GameManager.gm.health -= damage;
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
        if (GameManager.gm.haveAmmo && Input.GetMouseButtonDown(0))
            {
            Debug.Log(GameManager.gm.ammoCount);

            GameObject p = Instantiate(Projectile, transform.position, transform.rotation);
                TimeBtwShot = StartTimeBtwShot;
                GameManager.gm.ammoCount -= 1;
            Debug.Log(GameManager.gm.ammoCount);
        }
        else
             {
            TimeBtwShot -= Time.deltaTime;
             }
        if (Input.GetMouseButtonDown(1) && timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyAICombat>().TakeDamage(damage);
                GameManager.gm.ammoCount -= 1;
                
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.P) && GameManager.gm.ThrowammoCount > 0)
        {
            Debug.Log(GameManager.gm.ammoCount);

            GameObject p = Instantiate(Projectile, transform.position, transform.rotation);
            timeBtwThrow = StartTimeBtwShot;
            GameManager.gm.ThrowammoCount -= 1;
            Debug.Log(GameManager.gm.ThrowammoCount);
        }

        if (Input.GetKeyDown(KeyCode.Space) && timeBtwPower <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, PowerRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyAICombat>().TakeDamage(GameManager.gm.damage);

            }
            timeBtwPower = startTimeBtwPower;
        }
        else
        {
            timeBtwPower -= Time.deltaTime;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.tag == "North Border")
        {
            Debug.Log("Its hit bitch");
            GameManager.gm.LevelLoader("North Border");
        }
        if (collision.tag == "South Border")
        {
            Debug.Log("Its hit bitch");
            GameManager.gm.LevelLoader("South Border");
        }
        if(collision.tag == "East Border")
        {
            Debug.Log("Its hit bitch");
            GameManager.gm.LevelLoader("East Border");
        }
        if(collision.tag == "West Border")
        {
            Debug.Log("Its hit bitch");
            GameManager.gm.LevelLoader("West Border");
        }
        if (collision.tag == "GunAmmo")
        {
            ammoCount += 1;
            GameManager.gm.ammoCount += 1;
            GameManager.gm.BulletsText.text = "Bullets: " + GameManager.gm.ammoCount;
        }
        if (collision.tag == "Throw Ammo")
        {
            GameManager.gm.ThrowammoCount += 1;
            GameManager.gm.ThrowAmmoText.text = "Throw ammo: " + GameManager.gm.ThrowammoCount;
        }
        if (collision.tag == "Health")
        {
            GameManager.gm.health += 1;
            GameManager.gm.HealthText.text = "Health: " + GameManager.gm.health;
        }
        if (collision.tag == "MegaHealth")
        {
            GameManager.gm.health += 10;
            GameManager.gm.HealthText.text = "Health: " + GameManager.gm.health;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    void Update()
    {
            if (Input.GetMouseButtonDown(1)&& timeBtwAttack <= 0)
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
    }
}

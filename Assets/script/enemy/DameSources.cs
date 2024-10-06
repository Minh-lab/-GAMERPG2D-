using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSources : MonoBehaviour
{
    public int dame = 1;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<enemyHeal>())
        {
            enemyHeal EnemyHealth = collision.gameObject.GetComponent<enemyHeal>();
            
            EnemyHealth.TakeDamage(dame);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("damekiem"))
        {
            enemyHeal enemyHeal = collision.gameObject.GetComponent<enemyHeal>();
            enemyHeal.TakeDamage(dame);
        }
    }
}

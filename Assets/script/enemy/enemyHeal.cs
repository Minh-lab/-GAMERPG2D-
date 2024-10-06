using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class enemyHeal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;
    private Knock knockPack;
    private GameObject player;
    private GameObject dan;
    private void Awake()
    {
        player = GameObject.Find("PLayer");
        knockPack = GetComponent<Knock>();
        dan = GameObject.Find("dan");
    }
    private void Start()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        knockPack.GetKnockedBack(player.transform, 15f);


    }
}

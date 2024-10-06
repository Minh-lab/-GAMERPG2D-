using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycay : MonoBehaviour
{
    public GameObject deadbush;
    public GameObject mauPre;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dan") || collision.CompareTag("damekiem"))
        {
            Instantiate(deadbush,transform.position,Quaternion.identity);
            roimau();
            Destroy(gameObject);
        }
    }
    void roimau()
    {
        float dropChance = 1f / 3f;
        float randomValue = Random.value;
        if (randomValue <= dropChance)
        {
            Instantiate(mauPre,transform.position, Quaternion.identity);
        }
    }
}

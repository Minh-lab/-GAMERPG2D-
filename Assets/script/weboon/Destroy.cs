using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public GameObject DanDFX;
    void Start()
    {
        Destroy(gameObject, time);  
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("quai"))
        {
            Instantiate(DanDFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("tuong"))
        {
            Instantiate(DanDFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("truongngaivat"))
        {
            Instantiate(DanDFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}

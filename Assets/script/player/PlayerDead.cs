using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float knockBackThrust = 12f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            Transform enemyTransform = collision.transform;
            GetKnockedBack(enemyTransform, knockBackThrust);
        }

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dan1"))
        {
            Transform enemyTransforms = collision.transform;
            GetKnockedBack(enemyTransforms, knockBackThrust);
        }
    }
    public void GetKnockedBack(Transform damageSoure, float knockBackThrust)
    {
        Vector2 difference = (transform.position - damageSoure.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }
    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(0.5f); // Đợi 0.5 giây trước khi đặt vận tốc về 0
        rb.velocity = Vector2.zero;
    }

}

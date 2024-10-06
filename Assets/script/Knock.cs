using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
public class Knock : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float sknockBackThrust = 12f;
    public bool isDead;
    public int mau = 5;
    public GameObject dametextprefab;
    public GameObject Pos;
    public TextMesh Textmesh;
    public bool canTakeDamage = true;
    public static Knock Instance;
    private Flash flash;
    public GameObject vangprefab;
    public GameObject EnemyDFXprefab;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dametextprefab.SetActive(false);
        Instance = this;
        flash = GetComponent<Flash>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (chet) return;
        if ((collision.CompareTag("dan") || collision.CompareTag("damekiem")) && canTakeDamage)
        {
            if (collision.CompareTag("dan"))
            {
                audioMannager.instance.PlaySFX(audioMannager.instance.bantrung);
            }
            Transform enemyTransform = collision.transform;
            GetKnockedBack(enemyTransform, sknockBackThrust);

            mau--;
            StartCoroutine(flash.FlashRoutine());
            Textmesh.text = "-1";
            GameObject dame = Instantiate(dametextprefab, Pos.transform.position, Quaternion.identity);
            Destroy(dame, 0.3f);

            if (mau <= 0)
            {
                quanliQuaiChet.instance.QuaiC--;
                quanliQuaiChet.instance.enemystart++;
                Instantiate(EnemyDFXprefab,transform.position,Quaternion.identity);
                Instantiate(vangprefab,transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            dame.SetActive(true);
            canTakeDamage = false;
            StartCoroutine(DamageCooldownRoutine());
        }
    }

    public void GetKnockedBack(Transform damageSoure, float knockBackThrust)
    {
        isDead = true;
        Vector2 difference = (transform.position - damageSoure.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }
    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(0.5f); 
        rb.velocity = Vector2.zero;
        isDead = false;
    }
    private IEnumerator DamageCooldownRoutine()
    {
        // Đợi một khoảng thời gian trước khi cho phép nhận sát thương lần nữa
        yield return new WaitForSeconds(0.1f);
        canTakeDamage = true;
    }
}

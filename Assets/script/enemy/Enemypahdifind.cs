
using UnityEngine;

public class Enemypahdifind : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    public Vector2 moveDir;
    private Knock knockback;
    private SpriteRenderer spriteRenderer;
    private EnemyCotroller enemyCotroller;
    private QuaibanLoai1 loai1;
    private void Awake()
    {
        knockback = GetComponent<Knock>();
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCotroller = GetComponent<EnemyCotroller>();
        loai1 = GetComponent<QuaibanLoai1>();
    }
    private void FixedUpdate()
    {
        if (knockback.isDead == false ) { 
            rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
            
        }
        if(moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }
}

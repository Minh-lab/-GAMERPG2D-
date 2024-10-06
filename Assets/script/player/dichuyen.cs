
using UnityEngine;
using UnityEngine.SceneManagement;

public class dichuyen : MonoBehaviour
{
    public static dichuyen istances;
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public float speed;
    private Rigidbody2D rb;
    private Animator animatior;
    public Vector3 MoveInput;
    private SpriteRenderer spriteRenderer;
    private float timerool;
    public float lucroll;
    public float Timeroll = 0.1f;
    bool isRoll;
    private bool facingLeft = false;
    public GameObject menu;
    bool ismenu = true;
    public GameObject resum;
    public float time = 0;
    public float timedoi = 2f;
    //public bool EnemyDead = true;
    //public Vector3 position;
    public TrailRenderer trailRenderer;
    public GameObject a;
    public dash thanhdash;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatior = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        istances = this;
        thanhdash.capnhapthoigian(time,timedoi);
    }
    private void Start()
    {
        transform.position = new Vector3(PlayerData.instance.playerdata.posX, PlayerData.instance.playerdata.posY, PlayerData.instance.playerdata.posZ);
       
        
    }
    private void Update()
    {
        time -= Time.deltaTime;
        thanhdash.capnhapthoigian(time, timedoi);
        if (Input.GetKeyDown(KeyCode.Space) && timerool <= 0 && time <= 0)
        {
            speed += lucroll;
            timerool = Timeroll;
            trailRenderer.emitting = true;
            isRoll = true;
            
        }
        if (timerool <= 0 && isRoll)
        {
            speed -= lucroll;
            isRoll = false;
            trailRenderer.emitting = false;
        }
        else if(isRoll)
        {
            timerool -= Time.deltaTime;
            time= timedoi;
            thanhdash.capnhapthoigian(time, timedoi);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            showmenu();
        }    
    }
    
    void FixedUpdate()
    {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");
        animatior.SetFloat("speed", MoveInput.sqrMagnitude);
        transform.position += MoveInput * speed * Time.deltaTime;
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (mousePos.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
            FacingLeft = true;    
        }
        else
        {
            spriteRenderer.flipX = false;
            FacingLeft = false;           
        }
    }
    public void showmenu()
    {
        if (ismenu)
        {
            menu.SetActive(true);
            resum.SetActive(false);
            Time.timeScale = 0;
            ismenu = false;

            // Lưu trạng thái player
            Vector3 currentPosition = a.transform.position;
            string currentSceneName = SceneManager.GetActiveScene().name;
            PlayerData.instance.SaveDataPlayer(currentPosition, currentSceneName);


            // Gọi lưu quái vật nếu nó còn sống
       //     if (Knock.Instance != null && !Knock.Instance.chet) // Kiểm tra nếu quái vật còn sống
       //     {             
       //         EnemyData.instance.SaveDataEnemy(Knock.Instance.transform.position, Knock.Instance.chet); // Lưu từng quái vật          
       //     }
       //     else
       //     {
       //// Lấy chỉ số index phù hợp
       //         EnemyData.instance.SaveDataEnemy(position, true);
       //     }
            
        }
        else
        {
            menu.SetActive(false);
            resum.SetActive(true);
            Time.timeScale = 1;
            ismenu = true;
        }
    }



}

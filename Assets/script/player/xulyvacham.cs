using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xulyvacham : MonoBehaviour
{
    public thanhmau thanhmau_;
    public int luongmautoida = 10;
    public int luongmauhientai;
    public TextMeshProUGUI vangText;
    public int vang = 0;
    public GameObject choilai;
    public static xulyvacham istance;
    [SerializeField] private Material FlashRed;
    [SerializeField] private float restoreDefaulMatTime = .2f;
    private SpriteRenderer spriteRenderer;
    private Material defaultMat;
    public GameObject playerDFX;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
        istance = this;

    }
    void Start()
    {
        luongmauhientai = luongmautoida;
        luongmauhientai = save.Instance.levelScorer.mau;
        vang = save.Instance.levelScorer.coin;
        vangText.SetText(vang.ToString());
        thanhmau_.capnhapthanhmau(luongmauhientai, luongmautoida);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("dan1"))
        {
            luongmauhientai -= 1;
            StartCoroutine(FlashRoutine());
            thanhmau_.capnhapthanhmau(luongmauhientai, luongmautoida);
        }
        if (luongmauhientai == 0)
        {
            
            
            Time.timeScale = 0;
            //StartCoroutine(Timedoi());
            choilai.SetActive(true);
        }
        if (collision.CompareTag("vang"))
        {
            vang++;
            vangText.SetText(vang.ToString());
            audioMannager.instance.PlaySFX(audioMannager.instance.Coin);
            Destroy(collision.gameObject);
            
        }
        if (collision.CompareTag("mau"))
        {
            luongmauhientai += 1;
            audioMannager.instance.PlaySFX(audioMannager.instance.Heal);
            if (luongmauhientai > luongmautoida) luongmauhientai = luongmautoida;
            thanhmau_.capnhapthanhmau(luongmauhientai, luongmautoida);
            
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            luongmauhientai -= 1;
            StartCoroutine(FlashRoutine());
            thanhmau_.capnhapthanhmau(luongmauhientai, luongmautoida);

        }
        if (luongmauhientai <= 0)
        {
            
            
            Time.timeScale = 0;
            //StartCoroutine(Timedoi());
            choilai.SetActive(true);
        }
    }
    public void hoisinh()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.position = new Vector3(PlayerData.instance.playerdata.posX, PlayerData.instance.playerdata.posY, PlayerData.instance.playerdata.posZ);
        save.Instance.updatemau(10);
        Time.timeScale = 1;
        choilai.SetActive(false);
    }
    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = FlashRed;
        yield return new WaitForSeconds(restoreDefaulMatTime);
        spriteRenderer.material = defaultMat;
    }
    //IEnumerator Timedoi()
    //{
    //    yield return new WaitForSeconds(1f);
    //    choilai.SetActive(true);
    //}
}

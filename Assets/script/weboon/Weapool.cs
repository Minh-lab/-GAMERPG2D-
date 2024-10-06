using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Weapool : MonoBehaviour
{
    public GameObject player;
    private ActiveWeapol activeWeapol;
    public float lucban = 50f;
    public GameObject danPrefab;
    public GameObject pos;
    float timeban;
    public float Timeban = 2f;
    private Animator animatior;
    private void Awake()
    {
        activeWeapol = GetComponentInParent<ActiveWeapol>();
        animatior = GetComponent<Animator>(); 
    }
    void Update()
    {
        RotateGun();
        timeban -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeban <= 0)
        {
            bansung();
            animatior.SetTrigger("cung");
            audioMannager.instance.PlaySFX(audioMannager.instance.CungBan);
        }
    }
    void RotateGun()
    {
        
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 mousee = mousePos - playerScreenPoint;
        float angle = Mathf.Atan2(mousee.y, mousee.x) * Mathf.Rad2Deg;
        if(mousePos.x < playerScreenPoint.x)
        {
            activeWeapol.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            activeWeapol.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }
    void bansung()
    {
        timeban = Timeban;
        GameObject gameObject = Instantiate(danPrefab, pos.transform.position, ActiveWeapol.Instance.transform.rotation);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * lucban, ForceMode2D.Impulse);

    }

}

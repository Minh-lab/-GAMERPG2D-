using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiem : MonoBehaviour
{
    public GameObject player;
    private ActiveKiem activeKiem;
    private Animator animator;
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPos;
    private GameObject slahAnim;
    private dichuyen dichuyenn;
    public GameObject Kiemcolider;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        activeKiem = GetComponentInParent<ActiveKiem>();
        dichuyenn = GetComponentInParent<dichuyen>();
    }
    void Start()
    {
        Kiemcolider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xoaykiem();
        if (Input.GetMouseButtonDown(0))
        {
            Kiemcolider.SetActive(true);
            audioMannager.instance.PlaySFX(audioMannager.instance.Kiemchem);
            animator.SetTrigger("attack");
            slahAnim = Instantiate(slashAnimPrefab,slashAnimSpawnPos.position, Quaternion.identity);
            slahAnim.transform.parent = this.transform.parent;
            
        }
       
    }
    void xoaykiem()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (mousePos.x < playerScreenPoint.x)
        {
            activeKiem.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            activeKiem.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void swingupflipAnim()
    {
        slahAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        if (dichuyenn.FacingLeft)
        {
            slahAnim.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
    public void swingDownflipAnim()
    {
        slahAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (dichuyenn.FacingLeft)
        {
            slahAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void donattack()
    {
        Kiemcolider.SetActive(false);
    }
}

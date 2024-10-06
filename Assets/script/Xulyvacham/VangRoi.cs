using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VangRoi : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private float Khoangcach = 5f;
    [SerializeField] private float MoveSpeed = 3;
    [SerializeField] private float tocdocong = .2f;
    private Vector3 moveDir;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,dichuyen.istances.transform.position) < Khoangcach)
        {
            moveDir = (dichuyen.istances.transform.position - transform.position).normalized;
            MoveSpeed += tocdocong;
        }
        else
        {
            rb.velocity = Vector3.zero;
            MoveSpeed = 0;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = MoveSpeed * moveDir * Time.deltaTime;
    }
}

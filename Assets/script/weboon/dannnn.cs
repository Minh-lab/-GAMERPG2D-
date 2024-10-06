using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dannnn : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        MoveProjectile();
       
    }
    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public float speed;
    public float maxrange;
    public float minrange;   
    public float timebandoi = 2f;
    public GameObject danprefab;
    [SerializeField]private int burstCount;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private float timebetweenBursts;
    public bool isShooting = false;
    [SerializeField][Range(0, 359)] private float angleSpread;
    [SerializeField] private float projectilesPerBurts;
    [SerializeField] private float startDistance = 0.1f;
    void Start()
    {
        
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= maxrange && Vector3.Distance(player.transform.position, transform.position) >= minrange)
            {
                if (!isShooting)
                {

                    StartCoroutine(ShootRoutine());

                }

            }
        }
        
        
    }
     
    private IEnumerator ShootRoutine()
    {
        isShooting = true;
        Debug.Log("ShootRoutine started");
        float startAngle, currentAngel, angleStep;
        TargetConeOFInFluenece(out startAngle, out currentAngel, out angleStep);
        for (int i = 0; i < burstCount;i++)
        {
            for (int j = 0; j < projectilesPerBurts; j++)
            {
                Debug.Log("Projectile: " + j);
                Vector2 pos = FindBulletSpawnPos(currentAngel);
                
                GameObject bullet = Instantiate(danprefab, pos, Quaternion.identity);
                bullet.transform.right = bullet.transform.position-transform.position;

                if(bullet.TryGetComponent(out dannnn dann))
                {
                    dann.UpdateMoveSpeed(speed);
                }
                currentAngel += angleStep;
                
            }
            currentAngel = startAngle;
            yield return new WaitForSeconds(timebetweenBursts);

            TargetConeOFInFluenece(out startAngle, out currentAngel, out angleStep);
        }
        Debug.Log("All bursts complete, waiting for restTime");
        yield return new WaitForSeconds(restTime);
        Debug.Log("ShootRoutine ended");
        isShooting = false;

    }
    private void TargetConeOFInFluenece(out float startAngle, out float currentAngel, out float angleStep)
    {
        Vector2 targetDirection = player.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x)* Mathf.Rad2Deg;
        startAngle = targetAngle;
        float endAngle = targetAngle;
        currentAngel = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0;
        if(angleSpread != 0)
        {
            angleStep = angleSpread / (projectilesPerBurts - 1);
            halfAngleSpread = angleSpread / 2f;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngel = startAngle;
        }
    }
    private Vector2 FindBulletSpawnPos(float currentAngel)
    {
        float x  = transform.position.x + startDistance * Mathf.Cos(currentAngel *Mathf.Deg2Rad);
        float y = transform.position.y + startDistance * Mathf.Sin(currentAngel * Mathf.Deg2Rad);
        Vector2 pos = new Vector2(x, y);
        return pos;
    }
}

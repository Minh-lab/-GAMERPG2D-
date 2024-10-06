using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaibanLoai1 : MonoBehaviour
{
    public float maxrange;
    public float minrange;
    private GameObject player;
    public GameObject danprefab;
    public bool isShooting = false;
    [SerializeField] private int burstCount;
    public float speed;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private float timebetweenBursts;
    public static QuaibanLoai1 instance;
    void Start()
    {
        instance = this;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= maxrange && Vector3.Distance(player.transform.position, transform.position) >= minrange)
        {
            if (!isShooting)
            {

                StartCoroutine(ShootRoutine());

            }

        }


    }
    private IEnumerator ShootRoutine()
    {
        isShooting =true;
        for(int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = player.transform.position - transform.position;
            GameObject newbullet = Instantiate(danprefab, transform.position, Quaternion.identity);
            newbullet.transform.right = targetDirection;
            if (newbullet.TryGetComponent(out dannnn dann))
            {
                dann.UpdateMoveSpeed(speed);
            }
            yield return new WaitForSeconds(timebetweenBursts);         
        }
        yield return new WaitForSeconds(restTime);
        isShooting=false;
    }
}

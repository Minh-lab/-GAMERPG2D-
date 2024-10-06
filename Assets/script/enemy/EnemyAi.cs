using System.Collections;

using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    private enum State
    {
        Roaming
    }
    private State state;
    private Enemypahdifind enemypahdifind;
    public Vector2 abc;
    
    
    private GameObject player;
    private void Awake()
    {
        state = State.Roaming;
        enemypahdifind = GetComponent<Enemypahdifind>();
        
        player = GameObject.Find("Player");
    }
    

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }
    private IEnumerator RoamingRoutine()
    {
        while(state == State.Roaming)
        {
           
            enemypahdifind.MoveTo(GetRoamingPosition());
            yield return new WaitForSeconds(2f);
        }
    }
    private Vector2 GetRoamingPosition()
    {
        abc =  new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
        return abc;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadlevel2 : MonoBehaviour
{
    // Start is called before the first frame update
    public string entryPoint = "CongD";
    [SerializeField] private Animator Animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            save.Instance.updatemau(xulyvacham.istance.luongmauhientai);
            save.Instance.updatecoin(xulyvacham.istance.vang);
            SceneTranspotison.Instance.entryPoint = entryPoint;
            //if (Knock.Instance != null && !Knock.Instance.chet)
            //{
            //    EnemyData.instance.SaveDataEnemy(Knock.Instance.transform.position, Knock.Instance.chet);
            //}
            //else
            //{
            //    EnemyData.instance.SaveDataEnemy(new Vector3(0, 0, 0), true);
            //}
            StartCoroutine(LoadLevel());

            PlayerData.instance.SaveDataPlayer(collision.transform.position, SceneManager.GetActiveScene().name);
        }

    }
    IEnumerator LoadLevel()
    {
        Animator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
        Animator.SetTrigger("start");
    }
}

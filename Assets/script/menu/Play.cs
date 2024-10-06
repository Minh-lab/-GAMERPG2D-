using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuHoi;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadscene()
    {
        if(save.Instance.levelScorer.mau == 0)
        {
            save.Instance.updatemau(10);
            save.Instance.updatecoin(0);
            PlayerData.instance.SaveDataPlayer(new Vector3(0, 0, 0),"man1");
            //EnemyData.instance.isnewgame = true;
            //EnemyData.instance.SaveDataEnemy(new Vector3(10f,10f,0),false);
            SceneManager.LoadScene(1);
        }
        else
        {
            menuHoi.SetActive(true);
        }
    }
    public void LoadScene01()
    {
        save.Instance.updatemau(10);
        save.Instance.updatecoin(0);
        PlayerData.instance.SaveDataPlayer(new Vector3(0, 0, 0),"man1");
        //EnemyData.instance.isnewgame = true;
        //EnemyData.instance.SaveDataEnemy(new Vector3(10f, 10f, 0), false);
        SceneManager.LoadScene(1);
    }
}

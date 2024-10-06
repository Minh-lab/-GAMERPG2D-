using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choitiep : MonoBehaviour
{
    public GameObject Loi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadscenes()
    {
        if(save.Instance.levelScorer.mau > 0)
        {
            save.Instance.isNewGame = false;
            
            SceneManager.LoadScene(1);
        }
        else
        {
            Loi.SetActive(true);
        }   
    }
    public void Continiu()
    {
        PlayerData.instance.LoadDataPlayer();
        //EnemyData.instance.LoadDataEnemy();
        string sceneNames = PlayerData.instance.playerdata.sceneName;
        if (!string.IsNullOrEmpty(sceneNames))
        {
            SceneManager.LoadScene(sceneNames);
        }
        

    }
}

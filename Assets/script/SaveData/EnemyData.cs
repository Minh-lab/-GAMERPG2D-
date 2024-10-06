using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class EnemySave
{
    public float PosX;
    public float PosY;
    public float PosZ;
    public bool isDead;
}
public class EnemyData : MonoBehaviour
{
    // Start is called before the first frame update
    private string EnemyFile = "Enemy.Json";
    public EnemySave enemySave;
    public static EnemyData instance;
    public bool isnewgame = true;
    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void SaveDataEnemy( Vector3 position, bool isDead)
    {


        enemySave.PosX = position.x;
        enemySave.PosY = position.y;
        enemySave.PosZ = position.z;
        enemySave.isDead = isDead;
        
        string EnemyJson = JsonUtility.ToJson(enemySave);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, EnemyFile), EnemyJson);
    }
    public void LoadDataEnemy()
    {
        string filePath = Path.Combine(Application.persistentDataPath, EnemyFile);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            enemySave = JsonUtility.FromJson<EnemySave>(json);
        }
        else
        {
            enemySave.PosX = 10f;
            enemySave.PosY = 0;
            enemySave.PosZ = 0;
            enemySave.isDead = false;
        }
    }
 
}

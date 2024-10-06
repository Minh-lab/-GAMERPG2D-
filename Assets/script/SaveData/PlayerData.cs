using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Playerdata
{
    public float posX;
    public float posY;
    public float posZ;
    public string sceneName;
}

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public Playerdata playerdata;
    private string playerJson = "player.json";
    private string sceneFile = "scene.json";
    public bool isNewGame = true;
    void Awake()
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
    public void SaveDataPlayer(Vector3 position,string scenename)
    {
        playerdata.posX = position.x;
        playerdata.posY = position.y;
        playerdata.posZ = position.z;
        playerdata.sceneName = scenename;
        string positionJson = JsonUtility.ToJson(playerdata);
        string sceneJson = JsonUtility.ToJson(scenename);
        File.WriteAllText(Path.Combine(Application.persistentDataPath,playerJson),positionJson);
        File.WriteAllText(Path.Combine(Application.persistentDataPath,sceneFile),sceneJson);
    }
    public void LoadDataPlayer()
    {
        string filePath = Path.Combine(Application.persistentDataPath,playerJson);
        
        playerdata = JsonUtility.FromJson<Playerdata>(File.ReadAllText(filePath));
        if(!File.Exists(filePath))
        {
             playerdata.posX = 0;
             playerdata.posY = 0;
             playerdata.posZ = 0;          
        }
    }
    public void LoadSceneName()
    {
        string filePath = Path.Combine(Application.persistentDataPath, sceneFile);
        if (!File.Exists(filePath))
        {
            playerdata.sceneName = "man1";
        }
        playerdata = JsonUtility.FromJson<Playerdata>(File.ReadAllText(filePath));

    }
}

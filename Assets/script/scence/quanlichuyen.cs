using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quanlichuyen : MonoBehaviour
{
   
    public Transform spawnPointB;
    public Transform spawnPointC;
    void Start()
    {
        // Khôi phục dữ liệu nhân vật
        PlayerData.instance.LoadDataPlayer();

        // Kiểm tra xem có dữ liệu đã lưu không
        if (!string.IsNullOrEmpty(PlayerData.instance.playerdata.sceneName))
        {
            // Đặt vị trí nhân vật dựa trên dữ liệu đã lưu
            transform.position = new Vector3(PlayerData.instance.playerdata.posX,
                                               PlayerData.instance.playerdata.posY,
                                               PlayerData.instance.playerdata.posZ);
        }
        else
        {
            if (SceneTranspotison.Instance.entryPoint == "CongB")
            {
                transform.position = spawnPointB.position;
            }
            if (SceneTranspotison.Instance.entryPoint == "CongC")
            {
                transform.position = spawnPointC.position;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

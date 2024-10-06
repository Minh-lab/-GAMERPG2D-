using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranspotison : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneTranspotison Instance;
    public string entryPoint;
    
    private void Awake()
    {
        // Kiểm tra xem có tồn tại một instance chưa, nếu chưa thì tạo, nếu có rồi thì hủy cái mới.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo object không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


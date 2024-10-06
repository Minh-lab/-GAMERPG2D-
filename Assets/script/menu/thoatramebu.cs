using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thoatramebu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Thoatmanhinh()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}

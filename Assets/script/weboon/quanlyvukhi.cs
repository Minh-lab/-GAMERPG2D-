using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quanlyvukhi : MonoBehaviour
{
    // Start is called before the first frame update
    public Image otrong1;
    public Image otrong2;
    public Image otrong3;
    public Image otrong4;
    public Image otrong5;
    public GameObject kiemGameObject;
    public GameObject cungGameObject;
   
    void Update()
    {
        batvukhi();
    }
    void batvukhi()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            otrong1.gameObject.SetActive(true);
            otrong2.gameObject.SetActive(false);
            otrong3.gameObject.SetActive(false);
            otrong4.gameObject.SetActive(false);
            otrong5.gameObject.SetActive(false);
            kiemGameObject.SetActive(true);
            cungGameObject.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            otrong1.gameObject.SetActive(false);
            otrong2.gameObject.SetActive(true);
            otrong3.gameObject.SetActive(false);
            otrong4.gameObject.SetActive(false);
            otrong5.gameObject.SetActive(false);
            kiemGameObject.SetActive(false);
            cungGameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            otrong1.gameObject.SetActive(false);
            otrong2.gameObject.SetActive(false);
            otrong3.gameObject.SetActive(true);
            otrong4.gameObject.SetActive(false);
            otrong5.gameObject.SetActive(false);
            kiemGameObject.SetActive(false);
            cungGameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            otrong1.gameObject.SetActive(false);
            otrong2.gameObject.SetActive(false);
            otrong3.gameObject.SetActive(false);
            otrong4.gameObject.SetActive(true);
            otrong5.gameObject.SetActive(false);
            kiemGameObject.SetActive(false);
            cungGameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            otrong1.gameObject.SetActive(false);
            otrong2.gameObject.SetActive(false);
            otrong3.gameObject.SetActive(false);
            otrong4.gameObject.SetActive(false);
            otrong5.gameObject.SetActive(true);
            kiemGameObject.SetActive(false);
            cungGameObject.SetActive(false);
        }

    }
}

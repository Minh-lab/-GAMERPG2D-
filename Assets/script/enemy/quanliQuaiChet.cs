using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class quanliQuaiChet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dongcong;
    public GameObject dongcong1;
    public int QuaiC = 7;
    public static quanliQuaiChet instance;
    public TextMeshProUGUI Text;
    public float enemystart = 0;
    public float enemymax;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(QuaiC == 0)
        {
            dongcong.SetActive(true);
            dongcong1.SetActive(false);
        }
        Text.text = string.Format("ENEMY : {0:0}/{1:0}", enemystart, enemymax);
    }
}

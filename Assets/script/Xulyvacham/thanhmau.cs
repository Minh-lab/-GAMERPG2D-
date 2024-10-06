using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhmau : MonoBehaviour
{
    // Start is called before the first frame update
    public Image thanhmau_;
    public void capnhapthanhmau(float luongmauhientai,float luongmautoida)
    {
        thanhmau_.fillAmount = luongmauhientai/luongmautoida;
    }
}

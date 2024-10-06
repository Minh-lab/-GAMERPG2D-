using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class dash : MonoBehaviour
{
    public Image thanhdash;
    public void capnhapthoigian(float thoigianhientai,float thoigiantoida)
    {
        thanhdash.fillAmount = thoigianhientai/thoigiantoida;
    }
}

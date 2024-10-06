using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapol : MonoBehaviour
{
    // Start is called before the first frame update
    public static ActiveWeapol Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

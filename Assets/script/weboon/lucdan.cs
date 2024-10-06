using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class lucdan : MonoBehaviour
{
    bool isRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight) transform.Translate(Vector3.right * 7f * Time.deltaTime);
        else transform.Translate(Vector3.left * 7f * Time.deltaTime);
    }
    public void check(bool isRight)
    {
        this.isRight = isRight;
    }
}

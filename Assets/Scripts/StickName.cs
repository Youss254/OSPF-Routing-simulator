using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickName : MonoBehaviour
{
    public Text nameLable;
    // Update is called once per frame
    void Update()
    {
        if (nameLable != null)
        {
            Vector3 namePose = Camera.main.WorldToScreenPoint(transform.position);
            nameLable.transform.position = namePose;
        }
        
    }
    
}




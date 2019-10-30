using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DisplayText : MonoBehaviour {
    public GameObject inputField;
    float doubleClickStart = 0;
   
    void OnMouseUp()
    {
        if ((Time.time - doubleClickStart) < 0.2f){

            inputField.SetActive(true);
            doubleClickStart = -1;
        }
        
        else
        {
         doubleClickStart = Time.time;
        }
    }
    
}

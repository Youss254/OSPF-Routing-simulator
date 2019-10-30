using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNameCustom : MonoBehaviour {
    public GameObject inputField;
    public  GameObject wirep;
    public Text customDebiText;
    public static bool changed=false;
    public void ValidateText()
    {
       customDebiText.text = inputField.GetComponent<InputField>().text;
        //int index = customDebiText.text.IndexOf(' ');
        wirep.name = customDebiText.text;
        changed = true;
        inputField.SetActive(false);
    }
}

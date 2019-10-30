using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StickField : MonoBehaviour {

    public InputField nameField;
    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(transform.position);
        nameField.transform.position = namePose;

    }
}

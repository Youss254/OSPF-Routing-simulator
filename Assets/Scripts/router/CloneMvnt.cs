using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneMvnt : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    public Toggle m_Toggle;

    void Start()
    {
        m_Toggle = GameObject.Find("ToggleCable").GetComponent<Toggle>();
    }
    void OnMouseDown()
    {
        if (!m_Toggle.isOn)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        
    }
    void OnMouseDrag()
    {
        if (!m_Toggle.isOn)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

    }
}

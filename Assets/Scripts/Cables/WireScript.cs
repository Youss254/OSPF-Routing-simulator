using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    GameObject Clonedwire;
    //public GameObject routerP;
    void OnMouseDown()
    {
        if (!gameObject.name.Contains("(Clone)"))
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            Clonedwire = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
            Clonedwire.AddComponent<CloneMvnt>();
            Clonedwire.AddComponent<ScaleWire>();
        }
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (!gameObject.name.Contains("(Clone)"))
        {
            Clonedwire.transform.position = curPosition;
        }

    }
}

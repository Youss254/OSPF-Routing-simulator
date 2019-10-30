using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour {
    void Update()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0.0f)
        {
            transform.position = Camera.main.ViewportToWorldPoint(screenPos);
        }

        else if (screenPos.x > Screen.width)
            transform.position = Camera.main.ViewportToWorldPoint(screenPos);

        if (screenPos.y < 0.0f)
        {
            transform.position = Camera.main.ViewportToWorldPoint(screenPos);
        }
        else if (screenPos.y > Screen.height)
            transform.position = Camera.main.ViewportToWorldPoint(screenPos);
    }
       
}

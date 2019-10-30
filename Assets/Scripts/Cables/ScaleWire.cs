using UnityEngine;
using System.Collections;

public class ScaleWire : MonoBehaviour
{

    //public GameObject wirePrefab;
    public float sizingFactor = 0.02f;
    //private GameObject lastSpawn = null;
    private float startSize;
    private float startX;

    void Update()
    { 
        if (Input.GetMouseButtonDown(1))
        {
            float positionZ = 10.0f;
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionZ);
            startX = position.x;
            position = Camera.main.ScreenToWorldPoint(position);
            //lastSpawn = Instantiate(wirePrefab, position, transform.rotation) as GameObject;
            startSize = gameObject.transform.localScale.z;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 size = gameObject.transform.localScale;
            size.x = startSize + (Input.mousePosition.x - startX) * sizingFactor;
            gameObject.transform.localScale = size;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z)) - transform.position);
        }
    }
}
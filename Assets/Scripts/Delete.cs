using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Delete : MonoBehaviour
{
    //GameObject textToDelete;
    Ray ray;
    RaycastHit rayHit;
    void Start()
    {
        //textToDelete = GameObject.FindGameObjectWithTag("NameR"); 
        //suppButton.GetComponent<Button>().onClick.AddListener(DeleteRouter);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Destroy(textToDelete);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.gameObject.name.Contains("R")){
                    Destroy(rayHit.collider.gameObject);
                    Destroy(rayHit.collider.gameObject.transform.GetChild(0).GetComponent<StickName>().nameLable);
                    Destroy(rayHit.collider.gameObject.transform.GetChild(3));
                }
            }
            }
        
    }
}

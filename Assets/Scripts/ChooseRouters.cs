using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRouters : MonoBehaviour
{
    Ray ray;
    RaycastHit rayHit;
    GameObject destinationObject;
    GameObject originObject;
    bool desiinationSelected = false;
    public Toggle p_Toggle;
    public Toggle m_Toggle;
    int nbrclicks=0;
    int origin;
    public Button startButt;
    void Start()
    {
        p_Toggle = GameObject.Find("PingToggle").GetComponent<Toggle>();
        m_Toggle = GameObject.Find("ToggleCable").GetComponent<Toggle>();
    }
    int Update()
    {
        if (p_Toggle.isOn)
        {
            m_Toggle.isOn = false;
            if (Input.GetMouseButtonDown(0) && !desiinationSelected && destinationObject == null)
            {
                //Destroy(textToDelete);
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out rayHit))
                {
                    if (rayHit.collider.gameObject.name.Contains("R"))
                    {
                        originObject = rayHit.collider.gameObject;
                        origin = int.Parse(originObject.name.Substring(1, 1));
                        Debug.Log("origin added");
                        rayHit.collider.gameObject.transform.GetChild(0).GetComponent<StickName>().nameLable.GetComponent<Outline>().enabled = true;
                        desiinationSelected = true;
                        return 0;
                    }
                }
               
            }
            if (Input.GetMouseButtonDown(0) && desiinationSelected && nbrclicks<=1)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out rayHit))
                {
                    if (originObject != rayHit.collider.gameObject && rayHit.collider.gameObject.name.Contains("R"))
                    {
                        rayHit.collider.gameObject.transform.GetChild(0).GetComponent<StickName>().nameLable.GetComponent<Outline>().enabled = true;
                        destinationObject = rayHit.collider.gameObject;
                        Debug.Log("destination added");
                        nbrclicks++;

                        startButt.onClick.AddListener(delegate
                        {
                            Graphe g = new Graphe();
                            g.PathResult(origin, int.Parse(destinationObject.name.Substring(1, 1)));
                        });
                         
                        /*Graphe g = new Graphe();
                        g.PathResult(origin, int.Parse(destinationObject.name.Substring(1, 1)));*/
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        return 0;
    }
}



using UnityEngine;
using UnityEngine.UI;
 using System.Collections;
using System.Collections.Generic;
public class cableCreation : MonoBehaviour
{
    public Toggle m_Toggle;
    public Toggle p_Toggle;
    Ray ray;
	int i=1;
	 private LineRenderer lineRenderer;
	 private LineRenderer lineRendererClone;
     public static List<List<GameObject>> couples = new List<List<GameObject>>();
     List<GameObject> tempList = new List<GameObject>();
    RaycastHit rayHit;
	GameObject originObject;
	GameObject destinationObject;
	bool desiinationSelected=false;
	public float lineDrawSpeed = 6f; 
	private float counter;
    private float dist;
    public GameObject wireC;
    public Text debi1;
    public Text debi2;
    public Text debiC;
    public Text unit1;
    public Text unit2;
    public Text unitC;
    string debitSelected;
    void Start(){
        m_Toggle = GameObject.Find("ToggleCable").GetComponent<Toggle>();
        p_Toggle = GameObject.Find("PingToggle").GetComponent<Toggle>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }


    int  Update(){
		destinationObject=null;
		if (m_Toggle.isOn==true&&!p_Toggle.isOn){
		 	if (Input.GetMouseButtonDown(0) && !desiinationSelected && destinationObject==null ){
				 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             	if(Physics.Raycast(ray, out rayHit)){
                    if (rayHit.collider.gameObject.name.Contains("R") && rayHit.collider.gameObject.name != "router") {
                        originObject = rayHit.collider.gameObject;
                        desiinationSelected = true;
                        lineRendererClone = new LineRenderer();
                        lineRendererClone = Instantiate(lineRenderer, lineRenderer.transform.position, lineRenderer.transform.rotation);
                        Destroy(lineRendererClone.gameObject.GetComponent<cableCreation>());
                        lineRendererClone.name = "LineRenderer" + i;
                        lineRendererClone.SetPosition(0, originObject.transform.position);
                        lineRendererClone.SetWidth(.15f, .15f);
                        lineRendererClone.transform.SetParent(originObject.transform);
                        lineRendererClone.name = debitSelected;
                        i++;
                        return 0;
                    }
                    if (rayHit.collider.gameObject.name == wireC.name&& ChangeNameCustom.changed==true)
                    {
                        debiC.GetComponent<Outline>().enabled = true;
                        unitC.GetComponent<Outline>().enabled = true;
                        debi1.GetComponent<Outline>().enabled = false;
                        unit1.GetComponent<Outline>().enabled = false;
                        debi2.GetComponent<Outline>().enabled = false;
                        unit2.GetComponent<Outline>().enabled = false;
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.SetColors(rayHit.collider.gameObject.GetComponent<Renderer>().material.color, rayHit.collider.gameObject.GetComponent<Renderer>().material.color);
                        //lineRendererClone.name = rayHit.collider.gameObject.name;
                        Debug.Log(rayHit.collider.gameObject.name);
                        debitSelected = wireC.name;
                        return 0;

                    }
                    if (rayHit.collider.gameObject.name == "10")
                    {
                        debi1.GetComponent<Outline>().enabled = true;
                        unit1.GetComponent<Outline>().enabled = true;
                        debi2.GetComponent<Outline>().enabled = false;
                        unit2.GetComponent<Outline>().enabled = false;
                        debiC.GetComponent<Outline>().enabled = false;
                        unitC.GetComponent<Outline>().enabled = false;
                        //rayHit.collider.gameObject.AddComponent<HighlightObject>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.SetColors(rayHit.collider.gameObject.GetComponent<Renderer>().material.color, rayHit.collider.gameObject.GetComponent<Renderer>().material.color);
                        //lineRenderer.tag = rayHit.collider.gameObject.name;
                        Debug.Log(rayHit.collider.gameObject.name);
                        debitSelected = "10";
                        return 0;
                    }
                    if (rayHit.collider.gameObject.name == "100")
                    {
                        debi2.GetComponent<Outline>().enabled = true;
                        unit2.GetComponent<Outline>().enabled = true;
                        debi1.GetComponent<Outline>().enabled = false;
                        unit1.GetComponent<Outline>().enabled = false;
                        debiC.GetComponent<Outline>().enabled = false;
                        unitC.GetComponent<Outline>().enabled = false;
                        //rayHit.collider.gameObject.AddComponent<HighlightObject>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.SetColors(rayHit.collider.gameObject.GetComponent<Renderer>().material.color, rayHit.collider.gameObject.GetComponent<Renderer>().material.color);
                        //lineRenderer.name = rayHit.collider.gameObject.name;
                        Debug.Log(rayHit.collider.gameObject.name);
                        debitSelected = "100";
                        return 0;
                    }
                }
			 }
			 
		if (originObject!=null)
			 lineRendererClone.SetPosition(1,Camera.main.ScreenToWorldPoint(Input.mousePosition));

		
				
		 if (Input.GetMouseButtonDown(0)&&desiinationSelected){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           	if(Physics.Raycast(ray, out rayHit)){
				   if (originObject!=rayHit.collider.gameObject&&rayHit.collider.gameObject.name.Contains("R"))
                    {
                 		destinationObject = rayHit.collider.gameObject;
					}
                    else
                    {
                        return 0;
                    }
                    foreach (List<GameObject> elem in couples)
                    {
                        if ((elem[0].name == originObject.name && elem[1].name == destinationObject.name) || (elem[1].name == originObject.name && elem[0].name == destinationObject.name))
                        {
                            destinationObject = null;
                            Debug.Log("Conection already exists!!");
                            return 0;
                        }
                    }
                    dist = Vector3.Distance(originObject.transform.position, destinationObject.transform.position);
            	float x = Mathf.Lerp(0, dist, dist);
           		Vector3 pointA = originObject.transform.position;
           		Vector3 pointB = destinationObject.transform.position;
          		Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
            	lineRendererClone.SetPosition(1, pointAlongLine);
				lineRendererClone.gameObject.AddComponent<cableFollowsConections>();
                //lineRendererClone.transform.SetParent(destinationObject.transform);
                cableFollowsConections cFC =lineRendererClone.gameObject.GetComponent<cableFollowsConections> ();
				cFC.originLimit=originObject;
				cFC.destinationLimit=destinationObject;
                tempList = new List<GameObject>();
                tempList.Add(originObject);
                tempList.Add(destinationObject);

                    lineRendererClone.name = debitSelected;
                    tempList.Add(lineRendererClone.gameObject);
                /*foreach (string e in tempList){
                        Debug.Log(e);
                    } */
                couples.Add(tempList);
                    foreach(List<GameObject> l in couples)
                    {
                        Debug.Log(l[0] + " " + l[1] + " " + l[2]);
                    }
                originObject =null;
				destinationObject=null;
				desiinationSelected=false;
				
			}
		}

        }
	if(!m_Toggle.isOn&&desiinationSelected)
        {
		destinationObject=null;
		originObject=null;
		desiinationSelected=false;
        Destroy(lineRendererClone);
        }
        return 0;
	}

}



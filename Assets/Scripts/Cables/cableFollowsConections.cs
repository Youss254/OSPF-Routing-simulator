using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cableFollowsConections : MonoBehaviour {

	public GameObject originLimit;
	public GameObject destinationLimit;
	float dist,counter;
	LineRenderer line; 
	void Start () {
		line =gameObject.GetComponent<LineRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(originLimit!=null&&destinationLimit!=null){
			/*  dist = Vector3.Distance(destinationLimit.transform.position, originLimit.transform.position);

      


            
            float x = Mathf.Lerp(0, dist, dist);
            Vector3 pointA = originLimit.transform.position;
            Vector3 pointB = destinationLimit.transform.position;
            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA; */
			
           line.SetPosition(0, originLimit.transform.position);
		   line.SetPosition(1,destinationLimit.transform.position);


        

		
	}

		
	}
}

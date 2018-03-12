using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public GameObject currentTarget;
	public int targetPos = 0;
	public List <PathNode> path;
	public float speed = 1.0f;
	float startTime ;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//if (target != null){
		//	transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
		//}

		if (path != null){
			if (path.Count == targetPos){
				//Debug.Log ("End of road");
				Destroy (gameObject);
			}
			else {
				PathNode tar = path[targetPos];
				if (tar != null){
					 float distanceBetween = Vector3.Distance(tar.transform.position, transform.position);
					 float distanceTime = (Time.time - startTime) * speed;
					 float reltiveTime = distanceTime / distanceBetween;

					if (distanceBetween == 0){
						Debug.Log("Reached Target " +  targetPos);
						targetPos++;
						startTime = Time.time;
						Debug.Log("Rotating by: " + tar.yRotate);
						transform.Rotate(0, tar.yRotate,0);
					}

					transform.position=Vector3.MoveTowards(transform.position,tar.transform.position,speed*Time.deltaTime);
				}
			}

		}
	}
}

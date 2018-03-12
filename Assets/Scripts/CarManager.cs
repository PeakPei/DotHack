using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

	public GameObject carPrefab;
	public List<PathNode> path;

	public float spawnInterval = 1.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnCar", 0.5f, Random.Range(5.0f,10.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnCar (){
		Debug.Log ("Spawning car");
		if (path != null && path.Count > 0){
			GameObject car = Instantiate (carPrefab,path[0].transform.position, path[0].transform.rotation);
			//car.transform.SetParent (GameObject.Find ("ImageTarget").transform);
			car.GetComponent<Car>().path = path;
			car.GetComponent<Car>().targetPos = 0;
		}
	}
}

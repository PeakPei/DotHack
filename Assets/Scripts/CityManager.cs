using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour {

	public Text temp;
	public GameObject treePrefab;
	public List<GameObject> treLocs;
	private int treeCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnclickEarthQuake(){
		temp.text = "EarthQuake";
	}

	public void OnClickTree(){
		GameObject loc = treLocs[Random.Range(0,treLocs.Count)];
		GameObject tree = Instantiate (treePrefab,loc.transform.position, Quaternion.identity);
	}

	public void OnClickMetor(){
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thoughts : MonoBehaviour {

	public string[] grandmaThoughts;
	public string[] grandpaThoughts;
	public string[] kidsThoughts;


	public string sendThoughts(string personName)
	{
		if (personName == "GrandMa") {
			return(grandmaThoughts [Random.Range (0, grandmaThoughts.Length)]);
		} else if (personName == "GrandPa") {
			return(grandpaThoughts [Random.Range (0, grandpaThoughts.Length)]);
		} else if (personName == "Kid") {
			return(kidsThoughts [Random.Range (0, kidsThoughts.Length)]);
		} else
			return ("Oh...");
	}
}

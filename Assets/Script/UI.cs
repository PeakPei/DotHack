using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public Animator panelAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenThoughtPanel()
	{
		if(!panelAnim.GetBool("Open"))
			panelAnim.SetBool ("Open", true);
	}
	public void CloseThoughtPanel()
	{
		panelAnim.SetBool ("Open", false);
	}
}

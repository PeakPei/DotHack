using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Animator panelAnim;

	public Animator powerPanelAnim;
	public Toggle rainMaker;
	public Slider dayNight;
	public Light directionalLight;
	public GameObject rain;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		directionalLight.intensity = dayNight.value;
		rain.SetActive (rainMaker.enabled);
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

	public void OpenPowerPanel()
	{
		powerPanelAnim.SetBool ("Open",!powerPanelAnim.GetBool("Open"));
	}





}

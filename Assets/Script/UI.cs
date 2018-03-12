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
	public GameObject[] UIElements;
	public AudioSource gameTheme;

	private bool audioFlag=false;

	// Use this for initialization
	void Start () {
		gameTheme = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.isActive) {
			PlaySound ();
			return;
		} else {
			if (!audioFlag) {
				audioFlag = true;
				PlaySound ();
			}
		}
		directionalLight.intensity = dayNight.value;
		rain.SetActive (rainMaker.isOn);
	}

	public void OpenThoughtPanel()
	{
		if(!panelAnim.GetBool("Open"))
			panelAnim.SetBool ("Open", true);
	}
	public void CloseThoughtPanel()
	{

		if (!GameManager.isActive) {

			return;
		}
		panelAnim.SetBool ("Open", false);
	}

	public void OpenPowerPanel()
	{
		if (!GameManager.isActive) {

			return;
		}
		powerPanelAnim.SetBool ("Open",!powerPanelAnim.GetBool("Open"));
	}

	void PlaySound()
	{
		if (GameManager.isActive && !gameTheme.isPlaying) {
			gameTheme.Play ();
		} else {
			gameTheme.Stop ();
			audioFlag = false;
		}
	}



}

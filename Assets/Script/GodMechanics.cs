﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class GodMechanics : MonoBehaviour {

	private RaycastHit hit;
	public Text thoughtsText;
	public Text wishText;
	private  Thoughts thoughts;
	private WishGranting wishes;
	private UI uiElements;
	public Sprite[] characterIcons;
	public Button wishButton;
	public GameObject explosionEffect;
	private UnityEngine.UI.Image characterIcon;
	//for testing

	private bool flag=false;

	// Use this for initialization
	void Start () {
		thoughts = GameObject.Find ("GameManager").gameObject.GetComponent<Thoughts> ();
		uiElements = GameObject.Find ("GameManager").gameObject.GetComponent<UI> ();
		wishes = GameObject.Find ("GameManager").gameObject.GetComponent<WishGranting> ();
		characterIcon = GameObject.Find ("CharacterIcon").gameObject.GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {//checking user input
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 1000f))
			{
				if (hit.transform.gameObject.tag == "House") {
					StartCoroutine (Explosion (hit.transform.gameObject));
				} else if(hit.transform.gameObject.tag == "Person") {
					LoadThoughts(hit.transform.gameObject.name);
				}
			}
		}
	}

	void LoadThoughts(string personName)
	{
		if (characterIcon != null) {
			if (personName == "GrandMa") {
				characterIcon.sprite = characterIcons [0];
				wishText.text="Need a House";
			}
			else if (personName == "GrandPa") {
				characterIcon.sprite = characterIcons [1];
				wishText.text="Need a Car";
			}
			else if (personName == "Kid") {
				characterIcon.sprite = characterIcons [2];

			}
		}
		uiElements.OpenThoughtPanel ();
		StopAllCoroutines();
		thoughtsText.text = "";
		StartCoroutine (GenerateThoughts (personName));
	}

	IEnumerator GenerateThoughts (string person)
	{
		thoughtsText.text = thoughts.sendThoughts (person);
		yield return new WaitForSeconds (Random.Range(2.5f,3f));
		StartCoroutine (GenerateThoughts (person));
	}

	public void WishCheck()
	{
		uiElements.CloseThoughtPanel ();
		wishes.GiveWish (wishText.text);
	}

	IEnumerator Explosion(GameObject target)
	{
		GameObject explode= Instantiate(explosionEffect,target.transform.position,target.transform.rotation);
		yield return new WaitForSeconds (1.2f);
		Destroy (explode);
		Destroy (target);
	}
}

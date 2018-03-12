using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishGranting : MonoBehaviour {

	public GameObject[] Items;
	public GameObject WishGrantEffect;
	public Transform[] spawnPositions;
	public static bool[] wishStatus;
	void Start()
	{
		wishStatus = new bool[Items.Length];
		for (int i = 0; i < wishStatus.Length; i++)
			wishStatus [i] = false;
	}
	void Update()
	{
		if (!GameManager.isActive)
			return;
	}
	IEnumerator GrantWish(string wish)
	{
		GameObject effect;
		if (wish == "Need a House") {
			effect = Instantiate (WishGrantEffect, spawnPositions[0].position, Quaternion.identity);
			yield return new WaitForSeconds (3.0f);
			Destroy (effect);
			Instantiate (Items[0], spawnPositions[0].position, Quaternion.identity);
			wishStatus [0] = true;
		}
		else if (wish == "Need a Car") {
			effect = Instantiate (WishGrantEffect, spawnPositions[1].position, Quaternion.identity);
			yield return new WaitForSeconds (3.0f);
			Destroy (effect);
			Instantiate (Items[1], spawnPositions[1].position, Quaternion.identity);
			wishStatus [1] = true;
		}

	}

	public void GiveWish(string wish)
	{
		StartCoroutine (GrantWish(wish));
	}
}

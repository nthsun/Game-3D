using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour {
	GameObject player;  
	DamageBoost damageBoost;
	bool flag;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		damageBoost = player.GetComponent <DamageBoost> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			flag = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			flag = false;
		}
	}

	void PickUped()
	{
		damageBoost.enableEffect();
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if (flag == true) {
			PickUped ();
		}
	}
}

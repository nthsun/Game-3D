using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootItem : MonoBehaviour {

	GameObject player;
	bool increased;

	string[] nameItem = {"FronstItem", "LightningItem", "SlimeItem", "StinkItem"};
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			increased = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			increased = false;
		}
	}

	void PickUped()
	{
		ManagerWeapons weapons = GameObject.FindGameObjectWithTag ("Weapons").GetComponent<ManagerWeapons>();
		string name = gameObject.name.Replace("(Clone)","");
		if (name == "FronstItem") {
			weapons.addWeapons("Frost");
		}

		if (name == "LightningItem") {
			weapons.addWeapons("Lightning");
		}

		if (name == "SlimeItem") {
			weapons.addWeapons("Slime");
		}

		if (name == "StinkItem") {
			weapons.addWeapons("Stink");
		}
		gameObject.SetActive(false);

	}
	// Update is called once per frame
	void Update () {
		if (increased == true) {
			PickUped ();
		}
	}
}

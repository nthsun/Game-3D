using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	public GameObject player;
	public string nameSinceNext;
	bool increased = false;
	bool nexting = false;

	// Use this for initialization
	void Awake () {
		gameObject.GetComponent<ParticleSystem> ().Play ();
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

	void NextLeveL()
	{

		PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
		ManagerWeapons weapons = GameObject.FindGameObjectWithTag ("Weapons").GetComponent<ManagerWeapons>();
		List<string> weaponsName = weapons.getNameWeapons ();

		Dictionary<string, object> paramsScene = new Dictionary<string, object> ();

		paramsScene.Add("weaponsName", weaponsName);
		paramsScene.Add("playerHealth", playerHealth.currentHealth);
		paramsScene.Add("score", ScoreManager.score);

		ScenesManager.Load(nameSinceNext, paramsScene);

		gameObject.SetActive(false);

	}
// Update is called once per frame

	void Update () {
		Debug.Log (ScoreManager.score);
		if (increased == true&&!nexting) {
			nexting = true;
			player.GetComponent<PlayerMovement> ().speed = 0;
			Invoke ("NextLeveL", 5);
		}
	}
}

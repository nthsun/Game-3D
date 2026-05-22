using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatePlayer : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		List<string> weaponsName = (List<string>)ScenesManager.getParam ("weaponsName");
		int health = (int)ScenesManager.getParam ("playerHealth");
		int score = (int)ScenesManager.getParam ("score");

		ScoreManager.score = score;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
		playerHealth.currentHealth = health;

		Slider sliderHealth = GameObject.FindGameObjectWithTag ("HealthUI").GetComponent <Slider> ();
		sliderHealth.value = health;

		ManagerWeapons weapons = GameObject.FindGameObjectWithTag ("Weapons").GetComponent<ManagerWeapons>();
		foreach (string nameWeapon in weaponsName) {
			weapons.addWeapons(nameWeapon);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

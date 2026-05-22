using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : MonoBehaviour {
	[SerializeField] GameObject speedBuff;
	PlayerShooting playerShooting;
	public float time = 5f;
	void Start() {
		playerShooting = GetComponentInChildren<PlayerShooting> ();
	}
	public void enableEffect() {
		speedBuff.SetActive (true);
		playerShooting.damagePerShot = Convert.ToInt32(playerShooting.damagePerShot * 1.5);
		StartCoroutine (disableEffect());
	}

	IEnumerator disableEffect() {
		yield return new WaitForSeconds (time);
		speedBuff.SetActive (false);
		playerShooting.damagePerShot = Convert.ToInt32(playerShooting.damagePerShot / 1.5);
	}
}

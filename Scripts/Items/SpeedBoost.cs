using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {
	[SerializeField] GameObject speedBuff;
	PlayerMovement playerSpeed;
	public float time = 5f;
	private float tmpSpeed;

	void Start() {
		playerSpeed = GetComponent<PlayerMovement> ();
		tmpSpeed = playerSpeed.speed;
	}

	public void enableEffect() {
		speedBuff.SetActive (true);
		playerSpeed.speed = playerSpeed.speed * 1.2f;
		StartCoroutine (disableEffect());
	}

	IEnumerator disableEffect() {
		yield return new WaitForSeconds (time);
		speedBuff.SetActive (false);
		playerSpeed.speed = playerSpeed.speed / 1.2f;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {
	[SerializeField] GameObject Shield;
	public float time = 5f;

	public void enableShield() {
		Shield.SetActive (true);
		StartCoroutine (disableShield());
	}

	IEnumerator disableShield() {
		yield return new WaitForSeconds (time);
		Shield.SetActive (false);
	}
		
}

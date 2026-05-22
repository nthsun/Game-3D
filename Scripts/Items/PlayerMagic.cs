using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour {
	[SerializeField] GameObject Magic;
	GameObject player;
	public float time = 3f;

	public void enableMagic() {
		Magic.SetActive (true);
		StartCoroutine (disableMagic());
	}

	IEnumerator disableMagic() {
		yield return new WaitForSeconds (time);
		Magic.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Magic.activeSelf) {
			Magic.transform.localPosition = player.transform.position;
		}
	}
}

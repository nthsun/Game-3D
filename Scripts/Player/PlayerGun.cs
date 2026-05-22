using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {
	[SerializeField] Transform gunParent;
	[SerializeField] GameObject ak47Pref;
	GameObject currentGun;
	void Start(){
		if (currentGun == null)
			currentGun = gunParent.GetChild (0).gameObject;
	}

	public void SwicthToAK47(){
		GameObject.Destroy (currentGun);
		currentGun = GameObject.Instantiate (ak47Pref) as GameObject;
		currentGun.transform.parent = gunParent;
		currentGun.transform.localPosition = Vector3.zero;
		currentGun.transform.localRotation = Quaternion.identity;
	}
}

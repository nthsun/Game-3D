using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerMana : MonoBehaviour {

	public Image manaUI;
	public GameObject button;
	public GameObject effect;

	float coundown=1f;
	float timer=0f;
	float mn= 0.015f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= coundown) {
			timer = 0f;
			if (manaUI.fillAmount <= 1 - mn) {
				manaUI.fillAmount += mn;
			} else {
				manaUI.fillAmount = 1f;
			}
		}

		if (manaUI.fillAmount >= 0.8f) {
			activeButton ();
		} else {
			unactioveButton ();
		}

		if (Input.GetButtonDown("e"))
		{
			if (manaUI.fillAmount >= 0.8f) {
				clickButton ();
			}
		}
	}

	public void clickButton() {
		Debug.Log ("click");
		manaUI.fillAmount -= 0.8f;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		Plane plane = new Plane(Vector3.zero,0);
		float dist;
		Vector3 targetPosition = player.transform.position;

		Ray ray = Camera.main.ScreenPointToRay(targetPosition);
		if (plane.Raycast (ray, out dist)) {
			Vector3 point = ray.GetPoint (dist);
			targetPosition = point;
		}
		//targetPosition.y += 0.5f;

		effect.transform.position = targetPosition;
		//effect.transform.GetChild (0).transform.position = targetPosition;
		effect.SetActive (true);
		Invoke ("turnOffFire", 3);
	}

	void turnOffFire() {
		effect.SetActive (false);
	}

	public void activeButton() {
		GameObject dim = button.transform.GetChild (0).gameObject;
		dim.SetActive (false);
		dim = button.transform.GetChild (1).gameObject;
		dim.SetActive (false);
		button.GetComponent<Button> ().interactable = true;
	}

	public void unactioveButton() {
		GameObject dim = button.transform.GetChild (0).gameObject;
		dim.SetActive (true);
		dim = button.transform.GetChild (1).gameObject;
		dim.SetActive (false);
		button.GetComponent<Button> ().interactable = false;
	}
			
}

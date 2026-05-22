using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerWeapons : MonoBehaviour {

	List<string> nameWeapons = new List<string>();
	List<GameObject> existentWeapons = new List<GameObject>();

	public List<GameObject> weapons;
	public List<GameObject> iconWeapons;

	int currIndex=0;

	// Use this for initialization
	void Awake () {
		nameWeapons.Add ("GunBarrel"); //1
		nameWeapons.Add ("Stink"); //2
		nameWeapons.Add ("Frost"); //3
		nameWeapons.Add ("Lightning"); //4
		nameWeapons.Add ("Slime"); //5

		addWeapons("GunBarrel");
		addWeapons("Stink");
		addWeapons("Frost");
		addWeapons("Lightning");
		addWeapons("Slime");
	}
	
	// Update is called once per frame
	void Update () {

		var pointer = new PointerEventData(EventSystem.current);

		if (Input.GetButtonDown("1"))
		{
			if (existentWeapons.Count > 0) {
				currIndex = 0;
				ExecuteEvents.Execute(existentWeapons[0], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

		if (Input.GetButtonDown("2"))
		{
			if (existentWeapons.Count > 1) {
				currIndex = 1;
				ExecuteEvents.Execute(existentWeapons[1], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

		if (Input.GetButtonDown("3"))
		{
			if (existentWeapons.Count > 2) {
				currIndex = 2;
				ExecuteEvents.Execute(existentWeapons[2], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

		if (Input.GetButtonDown("4"))
		{
			if (existentWeapons.Count > 3) {
				currIndex = 3;
				ExecuteEvents.Execute(existentWeapons[3], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

		if (Input.GetButtonDown("5"))
		{
			if (existentWeapons.Count > 4) {
				currIndex = 4;
				ExecuteEvents.Execute(existentWeapons[4], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

		if (Input.GetButtonDown("q"))
		{
			if (currIndex + 1 >= existentWeapons.Count) {
				currIndex = 0;
				ExecuteEvents.Execute (existentWeapons [0], pointer, ExecuteEvents.pointerClickHandler);
			} else {
				Debug.Log (currIndex);
				ExecuteEvents.Execute(existentWeapons[currIndex + 1], pointer, ExecuteEvents.pointerClickHandler);
			}
		}

	}

	public void addWeapons(string nameWeapon) {
		Debug.Log (nameWeapon);
		int indexWeapon = nameWeapons.FindIndex (name => name == nameWeapon);
		if (indexWeapon < 0 || indexWeapon >= weapons.Count) {
			return;
		}
		GameObject weapon = weapons [indexWeapon];
		GameObject button = iconWeapons [indexWeapon];
		int check = existentWeapons.FindIndex (w => w.name == button.name);

		if (check != -1) {
			return;
		}
		existentWeapons.Add (button);

		int index = existentWeapons.FindIndex (b => button.name == b.name);
		Button weaponButton = button.GetComponent<Button> ();

		weaponButton.onClick.AddListener (delegate {changeWeapon (button, weapon);currIndex=index;});

		if (existentWeapons.Count == 1) {
			currIndex = 0;
			button.transform.GetChild (0).gameObject.SetActive(false);;
			weapon.SetActive (true);
		}

		button.SetActive (true);
	}

	public void changeWeapon(GameObject button, GameObject weapon) {
		Debug.Log (button.name + weapon.name);
		foreach (GameObject w in weapons) {
			w.SetActive (false);
		}
		GameObject dim;
		foreach (GameObject b in existentWeapons) {
			dim = b.transform.GetChild (0).gameObject;

			dim.SetActive (true);
		}

		dim = button.transform.GetChild (0).gameObject;
		dim.SetActive(false);
		weapon.SetActive (true);
	}
		
	public List<string> getNameWeapons() {
		List<string> listName = new List<string> ();
		foreach (GameObject button in existentWeapons) {
			int index = iconWeapons.FindIndex (w => w.name == button.name);
			if (index != -1) {
				listName.Add (nameWeapons [index]);
			}
		}
		return listName;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaItem : MonoBehaviour {
	public float mana;
	Image manaUI;
	GameObject player;  
	PlayerMagic playerMagic;
	bool flag;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerMagic = player.GetComponent <PlayerMagic> ();
		manaUI = GameObject.FindGameObjectWithTag ("ManaUI").GetComponent<Image> ();;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			flag = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			flag = false;
		}
	}

	void PickUped()
	{
		if (manaUI.fillAmount <= 1 - mana) {
			manaUI.fillAmount += mana;
		} else {
			manaUI.fillAmount = 1f;
		}
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if (flag == true) {
			PickUped ();
		}
	}
}

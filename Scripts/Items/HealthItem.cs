// vat pham hoi mau
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompleteProject
{
	public class HealthItem : MonoBehaviour {

		GameObject player;  
		PlayerHealth playerHealth;
		//PlayerGun playerGun;
		bool increased;

		// Use this for initialization
		void Start () {
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
			//playerGun = player.GetComponent <PlayerGun> ();
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

		void PickUped()
		{
			//playerGun.SwicthToAK47 ();
			playerHealth.IncreasedHealth ();
			gameObject.SetActive(false);
		}
		// Update is called once per frame
		void Update () {
			if (increased == true) {
				PickUped ();
			}
		}
	}
}

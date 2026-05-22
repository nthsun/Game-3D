using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShooting : MonoBehaviour {
	// public int damagePerShot = 200;
	// bool flag;
	// private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
	// // Use this for initialization
	// void Start () {
	// }
		
	// void OnParticleCollision(GameObject other) {
	// 	Debug.Log ("kill");
	// 	EnemyHealth enemyHealth = gameObject.GetComponent<EnemyHealth> ();
	// 	enemyHealth.TakeDamage (damagePerShot);
	// }

	public int damagePerShot = 200;
	GameObject enemy;
	EnemyHealth enemyHealth;
	private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
	// Use this for initialization
	void Start () {

	}

	void OnParticleCollision(GameObject other) {
		enemyHealth = other.GetComponent<EnemyHealth> ();
		if (enemyHealth == null)
			return;
		enemyHealth.TakeDamage (damagePerShot);
	}
}

using UnityEngine;
using System.Collections.Generic;

public class BossManager : MonoBehaviour
{
	public PlayerHealth playerHealth;

	public GameObject enemyBoss;
	public float spawnTime;
	public GameObject[] items;
	public int[] probabilities;
	public float scale;
	public int hearth=100;
	public int speed=3;
	public int dameAttack=3;
	float timeCurr = 0;
	public Transform[] spawnPoints;
	GameObject boss;

	bool checkSpawn = false;


	void Start ()
	{
		
	}

	void Update() {
		timeCurr += Time.deltaTime;

		if (timeCurr > spawnTime && !checkSpawn) {
			checkSpawn = true;
			Spawn ();
		}
	}

	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0)
		{
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		boss = (GameObject)Instantiate (enemyBoss, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		boss.transform.localScale = scale * boss.transform.localScale;
		EnemyHealth enemyHealth = boss.GetComponent<EnemyHealth> ();
		enemyHealth.currentHealth = hearth;
		enemyHealth.startingHealth = hearth;

		ItemManager itemManager = boss.GetComponent<ItemManager> ();
		if (itemManager != null) {
			for (int i = 0; i < items.Length; ++i) {
				itemManager.items.Add (items [i]);
				itemManager.probabilities.Add(probabilities [i]);
			}
		}
			
		boss.GetComponent<EnemyAttack> ().attackDamage = dameAttack;

		boss.GetComponent<EnemyMovement> ().setSpeed (speed);

	}
}

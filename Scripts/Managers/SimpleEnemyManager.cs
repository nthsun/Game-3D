using UnityEngine;

public class SimpleEnemyManager : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public float[] spawnTimes;
	public int[] enemyCounts;
	float timeBeetwenSpawn = 0.5f;
	public GameObject enemy;
//	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	float timerSpawn;
	float timerBeetwenSpawn;
	bool[] isSpawns;


	void Start ()
	{
//		InvokeRepeating ("Spawn", spawnTime, spawnTime);

		isSpawns = new bool[spawnTimes.Length];
	}

	void Update ()
	{
		timerSpawn += Time.deltaTime;
		timerBeetwenSpawn += Time.deltaTime;
		CheckSpawn ();
	}

	void CheckSpawn() {
		for (int i = 0; i < isSpawns.Length; i++) {
			if (!isSpawns [i] && timerSpawn >= spawnTimes[i] && enemyCounts[i] > 0 && timerBeetwenSpawn >= timeBeetwenSpawn) {
				Spawn ();
				enemyCounts [i]--;
				if (enemyCounts [i] <= 0) {
					isSpawns [i] = true;
				}
			}
		}
	}

	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0f)
		{
			return;
		}
		timerBeetwenSpawn = 0f;

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject enemyClone = (GameObject) Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}

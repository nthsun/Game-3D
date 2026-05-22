using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkEndGame : MonoBehaviour {
	public GameObject GameOverText;

	BossManager[] bossManager;
	bool condition = false;
	float timer = 0f;
	float bossFinish = 0f;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < bossManager.Length; ++i) {
			if (!bossManager [i].isActiveAndEnabled) {
				continue;
			}

			if(bossManager[i].spawnTime > bossFinish)	{
				bossFinish = bossManager[i].spawnTime;
			}
		}
	}

	void Awake () {
		bossManager = gameObject.GetComponents<BossManager> ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Debug.Log (bossFinish);
		if (!condition&&(bossFinish + 5) < timer) {
			GameObject[] objects = ScenesManager.FindGameObjectsWithLayer ("Shootable");

			int count = 0;
			for (int i = 0; i < objects.Length; ++i) {
				EnemyAttack enemy = objects[i].GetComponent<EnemyAttack>();
				if (enemy != null) {
					count++;
				}
			}

			Debug.Log (count);

			if (count == 0) {
				GameOverText.GetComponent<GameOverManager> ().endGame ();
				condition = true;
			}
		}
	}
}


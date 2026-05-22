using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	public List<GameObject> items;
	public List<int> probabilities;
	EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
		enemyHealth = GetComponent<EnemyHealth> ();
	}
		
	public void fallItem() {
		for (int i = 0; i < items.Count; i++) {
			if (Random.Range (1, 100 / probabilities[i]) == 1) {
				GameObject rndItem = items [i];
				Vector3 pos = new Vector3 ();
				pos.x = transform.position.x + Random.Range(-1, 2);
				pos.y = rndItem.transform.position.y;
				pos.z = transform.position.z + Random.Range(-1, 2);
				rndItem = (GameObject) Instantiate (rndItem, pos, Quaternion.identity);
			}			
		}
	}

	public void setProbForItems(int[] prob) {
		for (int i = 0; i < probabilities.Count; i++) {
			probabilities [i] = prob[i];
		}
	}
}

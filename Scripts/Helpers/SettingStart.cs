using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingStart : MonoBehaviour {
	public List<GameObject> enemies;
	// Use this for initialization
	void Start () {
		//paramsScene.Add("data_continue", savedGame);

		object data = ScenesManager.getParam ("data_continue");

		if (data != null) {

			Game game_old = (Game)data;

			setScore (game_old.score);

			_Player _player = game_old.player;

			setHealth (_player.currentHealth);

			GameObject player = GameObject.FindGameObjectWithTag ("Player");

			player.transform.position = new Vector3 (_player.positionX, _player.positionY, _player.positionZ);
			player.transform.rotation = Quaternion.Euler(_player.rotationX, _player.rotationY, _player.rotationZ);
			player.transform.localScale = new Vector3 (_player.scaleX, _player.scaleY, _player.scaleZ);

			ManagerWeapons weapons = GameObject.FindGameObjectWithTag ("Weapons").GetComponent<ManagerWeapons>();
			foreach (string nameWeapons in _player.weapons) {
				weapons.addWeapons(nameWeapons);
			}



			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			playerHealth.currentHealth = _player.currentHealth;


			List<_Enemy> _enemies = game_old.enemies;
			foreach(_Enemy _enemy in _enemies) {
				if (_enemy.name==null||_enemy.name=="") {
					continue;
				}

				string nameEnemy = _enemy.name.Replace("(Clone)","");

				GameObject enemy = enemies.Find(e => e.name == nameEnemy);

				if (enemy != null) {
					enemy.transform.position = new Vector3 (_enemy.positionX, _enemy.positionY, _enemy.positionZ);
					enemy.transform.rotation = Quaternion.Euler(_enemy.rotationX, _enemy.rotationY, _enemy.rotationZ);
					enemy.transform.localScale = new Vector3 (_enemy.scaleX, _enemy.scaleY, _enemy.scaleZ);
					enemy.SetActive (true);

					EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth> ();
					enemyHealth.currentHealth = _enemy.currentHealth;

					Instantiate (enemy);
				}
			}

			Debug.Log ("continue" + game_old.score);
		}
	}
		
	void setScore(int score) {
		ScoreManager.score = score;
	}

	void setHealth(int health) {
		Slider sliderHealth = GameObject.FindGameObjectWithTag ("HealthUI").GetComponent <Slider> ();
		sliderHealth.value = health;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoad {
	
	public static Game savedGame = new Game();

	//it's static so we can call it from anywhere
	public static void Save() {

		Game gameCurr = new Game ();

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		List<_Enemy> _enemies = new List<_Enemy>();
		int i = 0;
		foreach (GameObject enemy in enemies) {
			_Enemy _enemy = new _Enemy ();
			_enemy.setTransform(enemy.GetComponent <Transform>());
			_enemy.currentHealth = enemy.GetComponent<EnemyHealth>().currentHealth;
			_enemy.name = enemy.name;
			_enemy.PublicKeyToken = i;
			++i;
			_enemies.Add (_enemy);
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		_Player _player = new _Player ();
		_player.setTransform(player.GetComponent <Transform>());
		_player.currentHealth = player.GetComponent <PlayerHealth> ().currentHealth;

		ManagerWeapons weapons = GameObject.FindGameObjectWithTag ("Weapons").GetComponent<ManagerWeapons>();
		_player.weapons = weapons.getNameWeapons ();

		gameCurr.enemies = _enemies;
		gameCurr.player = _player;
		gameCurr.score = ScoreManager.score;

		//SceneManagement.Scene.name;
		gameCurr.scence = SceneManager.GetActiveScene().name;

		savedGame = gameCurr;
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedGame);

		Debug.Log ("Save game");
		file.Close();
	}   

	public static void Load() {
		Debug.Log ("Load game");
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.savedGame = (Game)bf.Deserialize(file);
			file.Close();

			Debug.Log (savedGame.score);

			Dictionary<string, object> paramsScene = new Dictionary<string, object> ();

			paramsScene.Add("data_continue", savedGame);
			ScenesManager.Load(savedGame.scence, paramsScene);

			Debug.Log ("Load game success");
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game { 

	public int score;
	public string scence;

	public List<_Enemy> enemies;
	public _Player player;

	public Game () {
		enemies = new List<_Enemy>();
		player = new _Player ();

		score = 0;
		scence = "level 01";
	}

}

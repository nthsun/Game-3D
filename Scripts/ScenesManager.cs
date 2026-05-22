using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager {
	
	private static Dictionary<string, object> parameters;

	public static void Load(string sceneName, Dictionary<string, object> parameters = null) {
		ScenesManager.parameters = parameters;
		SceneManager.LoadScene(sceneName);
	}

	public static void Load(string sceneName, string paramKey, object paramValue) {
		ScenesManager.parameters = new Dictionary<string, object>();
		ScenesManager.parameters.Add(paramKey, paramValue);
		SceneManager.LoadScene(sceneName);
	}

	public static Dictionary<string, object> getSceneParameters() {
		return parameters;
	}

	public static object getParam(string paramKey) {
		if (parameters == null)
			return null;

		if (parameters.ContainsKey (paramKey)) {
			return parameters [paramKey];
		} else {
			return null;
		}
	}

	public static void setParam(string paramKey, object paramValue) {
		if (parameters == null) {
			ScenesManager.parameters = new Dictionary<string, object> ();
		}
		ScenesManager.parameters.Add(paramKey, paramValue);
	}

	public static void ChangeLayersRecursively(Transform trans, string name)
	{
		foreach (Transform child in trans)
		{
			child.gameObject.layer = LayerMask.NameToLayer(name);
			ChangeLayersRecursively(child, name);
		}
	}


	public static GameObject[] FindGameObjectsWithLayer (string layerName) {
		int layer = LayerMask.NameToLayer (layerName);
		if (layer < 0) {
			return null;
		}
		GameObject[] goArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		List<GameObject> goList = new List<GameObject>();
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) {
				goList.Add(goArray[i]);
			}
		}
		if (goList.Count == 0) {
			return null;
		}
		return goList.ToArray();
	}
}

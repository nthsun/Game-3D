using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Slider sliderVolume;
	GameObject[] listAudioSource;

	void Start ()
	{
		listAudioSource = GameObject.FindGameObjectsWithTag("AudioSource");
		foreach(GameObject audioSource in  listAudioSource) {
			audioSource.GetComponent <AudioSource>().volume = sliderVolume.value;
		}
		sliderVolume.onValueChanged.AddListener (SetVolume);
	}

	public void PlayGame () {
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		Dictionary<string, object> paramsScene = new Dictionary<string, object> ();
		paramsScene.Add("audioSource", sliderVolume.value);
		ScenesManager.Load("level 01", paramsScene);
	}

	public void QuitGame() {
		Debug.Log ("QUIT");
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}

	void SetVolume(float volume)
	{
		Debug.Log ("change volumn" + volume);

		foreach(GameObject audioSource in  listAudioSource) {
			audioSource.GetComponent <AudioSource>().volume = volume;
		}

		//GetComponent<AudioSource>().volume = volume;
	}


}

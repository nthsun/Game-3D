using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    //[Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
    public GameObject LoadGamePanel;

	GameObject[] listMusic;
	GameObject[] listSound;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

		//2 brightness
		//3 contrast
		//4 volume
		//5 sound
		Slider sliderBrightness = GamePanel.transform.GetChild (2).GetComponentInChildren <Slider> ();
		Slider sliderVolume = GamePanel.transform.GetChild (4).GetComponentInChildren <Slider> ();
		Slider sliderVolumeSound = GamePanel.transform.GetChild (5).GetComponentInChildren <Slider> ();

		listMusic = GameObject.FindGameObjectsWithTag("Music");
		foreach(GameObject music in  listMusic) {
			music.GetComponent <AudioSource>().volume = sliderVolume.value;
		}
		sliderVolume.onValueChanged.AddListener (SetVolumeMusic);
//
//		listSound = GameObject.FindGameObjectsWithTag("Sound");
//		foreach(GameObject sound in  listSound) {
//			sound.GetComponent <AudioSource>().volume = sliderVolumeSound.value;
//		}
//		sliderVolumeSound.onValueChanged.AddListener (SetVolumeSound);
//

		sliderBrightness.onValueChanged.AddListener (setBrightness);


        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
    }

	void SetVolumeMusic(float volume)
	{
		Debug.Log ("change volumn" + volume);

		foreach(GameObject music in  listMusic) {
			music.GetComponent <AudioSource>().volume = volume;
		}
	}

	void SetVolumeSound(float volume)
	{
		Debug.Log ("change volumn" + volume);

		foreach(GameObject sound in  listSound) {
			sound.GetComponent <AudioSource>().volume = volume;
		}
	}

	void setBrightness(float value)
	{
		Debug.Log ("change Brightness" + value);

		RenderSettings.ambientLight = new Color (value,value,value,1);
	}



    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
       
    }

    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
        
    }

    public void openOptions_Game()
    {
        //enable respective panel
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Controls()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Gfx()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openContinue_Load()
    {
//        //enable respective panel
//        GamePanel.SetActive(false);
//        ControlsPanel.SetActive(false);
//        GfxPanel.SetActive(false);
//        LoadGamePanel.SetActive(true);
//
//        //play anim for opening game options panel
//        anim.Play("OptTweenAnim_on");
//
//        //play click sfx
//        playClickSound();

		SaveLoad.Load ();

    }

    public void newGame()
    {
		Dictionary<string, object> paramsScene = new Dictionary<string, object> ();

		Slider sliderVolume = GamePanel.transform.GetChild (4).GetComponentInChildren <Slider> ();
		paramsScene.Add("audioSource", sliderVolume.value);
		ScenesManager.Load("level 01 Complete", paramsScene);
    }
    #endregion

    #region Back Buttons

    public void back_options()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");

        //disable BLUR
       // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");
        
        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
		Debug.Log ("QUIT");
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
		Debug.Log ("playHoverClip");
    }

    void playClickSound() {
		Debug.Log ("playClickSound");
    }


    #endregion
}

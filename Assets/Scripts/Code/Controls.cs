using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour
{
	public bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	public GameObject inGameMenuUI;

	public GameObject wonScreen;

	public TMP_Text scoreNumberText;
	public TMP_Text inGameTimerText;
	public TMP_Text wonTimerText;

	void Start(){
		Resume();
	}

    // Update is called once per frame
    void Update()
    {
		int.TryParse(scoreNumberText.text, out int returnValue);
		if (returnValue >= 1){
			WonGame();
		}
        if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameIsPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
    }

	void Pause(){
		pauseMenuUI.SetActive(true);
		inGameMenuUI.SetActive(false);
		wonScreen.SetActive(false);
		GameIsPaused = true;
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	void Resume(){
		pauseMenuUI.SetActive(false);
		inGameMenuUI.SetActive(true);
		wonScreen.SetActive(false);
		GameIsPaused = false;
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false; 
	}

	void WonGame(){
		pauseMenuUI.SetActive(false);
		inGameMenuUI.SetActive(false);
		wonScreen.SetActive(true);
		wonTimerText.text = inGameTimerText.text;
		GameIsPaused = true;
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}

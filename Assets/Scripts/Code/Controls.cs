using UnityEngine;

public class Controls : MonoBehaviour
{
	public bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	public GameObject inGameMenuUI;

    // Update is called once per frame
    void Update()
    {
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
		GameIsPaused = true;
		Time.timeScale = 0;
	}

	void Resume(){
		pauseMenuUI.SetActive(false);
		inGameMenuUI.SetActive(true);
		GameIsPaused = false;
		Time.timeScale = 1;
	}
}

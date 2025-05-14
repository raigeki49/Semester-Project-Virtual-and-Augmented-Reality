using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void QuitGame(){
		Application.Quit();
	}

	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

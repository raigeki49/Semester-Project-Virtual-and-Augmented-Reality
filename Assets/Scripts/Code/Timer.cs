using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer: MonoBehaviour
{

	public TMP_Text timerText;
	float currentTime = 0.0f;

	bool hasStopped = false;

	public void Update(){
		if (!hasStopped){
			currentTime += Time.deltaTime;
			timerText.text = currentTime.ToString("F2");
		}
	}

	public void stop(){
		hasStopped = true;
	}
}
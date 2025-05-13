using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Star: MonoBehaviour
{

	public Timer timer;

	public TMP_Text scoreNumberText;
	
	private void Start(){
		float x = Random.Range(-80, 60);
		float y = Random.Range(45, 60);
		float z = Random.Range(0, 140);

		transform.position = new Vector3(x, y, z);
	}
	private void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Player"){ 
			int.TryParse(scoreNumberText.text, out int returnValue);
			scoreNumberText.text = (returnValue + 1).ToString();
			changePostion();
		}
    }

	private void changePostion(){
		float x = Random.Range(-80, 60);
		float y = Random.Range(60, 80);
		float z = Random.Range(0, 140);

		transform.position = new Vector3(x, y, z);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade: MonoBehaviour
{
	public float targetTime;

	public GameObject explosionEffect;

	private bool hasExploded = false;

	public AudioClip[] sounds;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	}

	private void Update(){
		targetTime -= Time.deltaTime;

		if (targetTime <= 0.0f && !hasExploded){
			timerEnded();
			hasExploded = true;
		}
	}

	void timerEnded(){
		GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

		Collider[] colliders = Physics.OverlapSphere(transform.position, 15f);

		foreach (Collider nearbyObjects in colliders){
			if (nearbyObjects.tag == "Physics" || nearbyObjects.tag == "Player"){
				Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
				if (rb != null){
					if (nearbyObjects.tag != "Player"){
						rb.constraints = RigidbodyConstraints.None;
						rb.isKinematic = false;
					}
					rb.AddExplosionForce(-1000f, transform.position, 15f);
				}
			}
		}
		source.clip = sounds[Random.Range(0, sounds.Length-1)];
		source.Play();
		Destroy(gameObject, source.clip.length - 1);
	}
}
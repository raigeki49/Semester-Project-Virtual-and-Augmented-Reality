using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket: MonoBehaviour
{
	public float targetTime = 20.0f;

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

	private void FixedUpdate(){
		transform.Translate(Vector3.forward * Time.deltaTime * 40f);
	}

	private void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag != "Player" && !hasExploded){ 
			GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
			hasExploded = true;

			Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

			foreach (Collider nearbyObjects in colliders){
				Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
				if (rb != null){
					rb.AddExplosionForce(1000f, transform.position, 10f, 3.0F);
					if (nearbyObjects.tag != "Player"){
						rb.constraints = RigidbodyConstraints.None;
					}
				}
			}
			source.clip = sounds[Random.Range(0, sounds.Length-1)];
			source.Play();
			Destroy(gameObject, source.clip.length - 1);
		}
    }

	void timerEnded(){
		Destroy(gameObject);
	}
}
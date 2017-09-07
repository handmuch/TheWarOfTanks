using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {
	Red, Blue, Green
}

public class Unit : MonoBehaviour {

	public bool isPlyer = false;
	public int health = 100;
	public Team team;
	public GameObject deadEffect;

	public void ApplyDamage(int damage) {
		if (!isPlyer) {
			if (health > damage) {
				health -= damage;
			} else {
				Destruct ();
			}
		}
	}

	public void Destruct(){
		if (!isPlyer) {
			if (deadEffect != null) {
				Instantiate (deadEffect, transform.position, transform.rotation);
			}

			Destroy (gameObject);
		}
	}
}

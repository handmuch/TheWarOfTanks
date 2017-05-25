using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public bool isEnemy = true;
	public int health = 100;
	public GameObject deadEffect;

	public void ApplyDamage(int damage) {
		if (isEnemy) {
			if (health > damage) {
				health -= damage;
			} else {
				Destruct ();
			}
		}
	}

	public void Destruct(){
		if (isEnemy) {
			if (deadEffect != null) {
				Instantiate (deadEffect, transform.position, transform.rotation);
			}

			Destroy (gameObject);
		}
	}
}

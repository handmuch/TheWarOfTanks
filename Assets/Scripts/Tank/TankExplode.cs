using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankExplode : MonoBehaviour {

	public float explosionRaduis;
	public float explosionForce;
	public GameObject explosionEffect;
	public float explosionTimeUp;
	public int damage;

	private LayerMask curLm;

	public void Init (LayerMask enemLayer) {
		curLm = enemLayer;
	}
		
	void OnCollisionEnter() {
		GameObject obj = Instantiate (explosionEffect, transform.position, transform.rotation) as GameObject;
		Destroy (gameObject);
		Destroy (obj, explosionTimeUp);

		Collider[] cols = Physics.OverlapSphere (transform.position, explosionRaduis, curLm);
		if (cols.Length > 0) {
			for (int i = 0; i < cols.Length; i++) {
				Rigidbody r = cols[i].GetComponent<Rigidbody> ();
				if (r != null) {
					r.AddExplosionForce (explosionForce, transform.position, explosionRaduis);
				}

				Unit u = cols[i].GetComponent<Unit> ();
				if (u != null) {
					u.ApplyDamage (damage);
				}
			}
		}
	}
}

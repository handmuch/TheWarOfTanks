using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : Unit {

	public GameObject player;
	public float moveSpeed;
	public float attackRange;
	public float shootCoolDown;

	private float timer;
	private TankShell tankShell;

	void Start(){
		tankShell = GetComponent<TankShell> ();
	}

	void FixedUpdate(){
		timer += Time.fixedDeltaTime;

		if (player == null) {
			return;
		}

		float dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist > attackRange) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		}

		transform.LookAt (player.transform.position);

		if (timer > shootCoolDown) {
			tankShell.Shoot ();
			timer = 0;
		}

	}
}

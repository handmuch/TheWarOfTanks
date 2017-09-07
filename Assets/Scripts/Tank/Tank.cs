using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

	public float moveSpeed;
	public float rotateSpeed;

	private TankShell tankShell;

	void Start() {
		tankShell = GetComponent<TankShell> ();
		tankShell.Init (team);
	}

	// Update is called once per frame
	void FixedUpdate () {

		//deltaTime上一帧执行时间
		//Debug.Log(Input.GetAxis("Horizontal1"));

		float horizonal = Input.GetAxis ("Horizontal1");
		float vertrail = Input.GetAxis ("Vertical1");
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime * vertrail);
		transform.Rotate (Vector3.down * -rotateSpeed * Time.deltaTime * horizonal);

		if (Input.GetKeyDown (KeyCode.Space)) {
			tankShell.Shoot ();
		}
	}
}

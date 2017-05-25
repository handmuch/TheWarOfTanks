using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShell : MonoBehaviour {

	public GameObject shell;
	public float shootPower;
	public Transform shootPoint;

	private AudioSource auidoSource;

	void Start ()
	{
		auidoSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKey (KeyCode.Space))
		{
			//fire
			Shoot();
		}
			
	}

	public void Shoot () {
		GameObject newShell = Instantiate (shell, shootPoint.position, shootPoint.rotation) as GameObject;
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		//速度
		r.velocity = shootPoint.forward * shootPower;
	}
}

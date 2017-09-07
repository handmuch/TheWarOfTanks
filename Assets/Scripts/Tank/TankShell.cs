using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShell : MonoBehaviour {

	public GameObject shell;
	public float shootPower;
	public float shootCoolDown;
	public Transform shootPoint;

	private AudioSource auidoSource;
	private LayerMask enemyLayer;
	private bool isWeaponReady = true;

	void Start () {
		auidoSource = GetComponent<AudioSource> ();
	}

	public void Init (Team team) {
		enemyLayer = LayerManager.GetEnemyLayer (team);
	}

	public void Shoot () {
		if (!isWeaponReady) {
			return;
		}

		GameObject newShell = Instantiate (shell, shootPoint.position, shootPoint.rotation) as GameObject;
		newShell.GetComponent<TankExplode> ().Init (enemyLayer);
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		//速度
		r.velocity = shootPoint.forward * shootPower;
		//播放音效
		auidoSource.Play ();
		isWeaponReady = false;
		//开始冷却
		StartCoroutine (weaponCoolDown ());
	} 

	IEnumerator weaponCoolDown (){
		yield return new WaitForSeconds (shootCoolDown);
		isWeaponReady = true;
	}
}

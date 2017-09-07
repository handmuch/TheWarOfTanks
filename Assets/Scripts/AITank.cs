using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AITank : Unit {

	public float searchEnmeyRange;
	public float moveSpeed;
	public float rotateSpeed;
	public float attackRange;


	private GameObject enemy;
	private NavMeshAgent nam;
	private TankShell tankShell;
	private LayerMask enemyLayerMask;

	void Start(){
		enemyLayerMask = LayerManager.GetEnemyLayer (team);
		nam = GetComponent<NavMeshAgent> ();
		tankShell = GetComponent<TankShell> ();
		tankShell.Init (team);
	}

	void Update(){

		if (enemy == null) {
			searchEnemy ();
			return;
		}
		float dist = Vector3.Distance (enemy.transform.position, transform.position);

		//攻击距离判断
		if (dist > attackRange) {
			nam.SetDestination (enemy.transform.position);
		} else {
			//停止并射击
			nam.ResetPath();
			//旋转，方向追踪玩家
			Vector3 dir = enemy.transform.position - transform.position;
			Quaternion wantedRotation = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotateSpeed * Time.deltaTime);
			tankShell.Shoot ();
		}
	}

	public void searchEnemy() {
		Collider[] cols = Physics.OverlapSphere (transform.position, searchEnmeyRange, enemyLayerMask);
		enemy = cols [Random.Range (0, cols.Length)].gameObject;
	}
}

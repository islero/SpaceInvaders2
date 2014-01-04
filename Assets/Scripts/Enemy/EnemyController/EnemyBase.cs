using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour {
	private GameObject[] enemyGameObject;

	private int rotate_move = 1;

	public void SetEnemyBase(GameObject[] enemyGameObjects){
		this.enemyGameObject = enemyGameObjects;
	}

	public void MoveLeftRight(float delta){
		foreach(GameObject selected_enemy in enemyGameObject){
			if (selected_enemy)
				selected_enemy.transform.position += new Vector3(0, -0.02f * delta, 0);
		}
	}

	public void MoveUpDown(float delta){		
		foreach(GameObject selected_enemy1 in enemyGameObject){
			if (selected_enemy1)
				selected_enemy1.transform.position += new Vector3(0, 0.03f * rotate_move * delta, 0);
		}
	}
	
	public void MoveDown(float delta){
		foreach(GameObject selected_enemy1 in enemyGameObject){
			if (selected_enemy1)
				selected_enemy1.transform.position += new Vector3(0, -0.06f * delta, 0);
		}
	}

	public abstract void SetRandom();
}
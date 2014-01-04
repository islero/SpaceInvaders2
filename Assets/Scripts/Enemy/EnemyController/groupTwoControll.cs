using UnityEngine;
using System.Collections;

public class groupTwoControll : EnemyBase {
	private int i = 0, setMove = 0;
	
	private GameObject[] enemyGameObjects;
	
	
	void Start(){
		enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
		SetEnemyBase(enemyGameObjects);
	}
	
	public override void SetRandom(){
		setMove = Random.Range(1, 3);
		if (setMove == 1){
			MoveLeftRight(Time.deltaTime);
		}
		if (setMove == 2){
			MoveDown(Time.deltaTime);
		}
		if (setMove == 3){
			MoveUpDown(Time.deltaTime);
		}
	}
	
	private void Update(){
		i++;
		if (i > 450 && Time.timeScale == 1){
			i = 0;
			SetRandom();
		}
		
		if (setMove == 1)
			MoveLeftRight(Time.deltaTime);
		
		if (setMove == 2)
			MoveDown(Time.deltaTime);
		
		if (setMove == 3)
			MoveUpDown(Time.deltaTime);
		
	}
}

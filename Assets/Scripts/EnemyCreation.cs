using UnityEngine;
using System.Collections;

public class EnemyCreation : MonoBehaviour {

	public Transform EnemyGroup1;
	public Transform EnemyGroup2;
	public Transform EnemyGroup3;

	private int enemyNextGroup;

	// Use this for initialization
	void Start () {
		Instantiate(EnemyGroup1, new Vector3(Random.Range(1.156839f, 3.798642f), 0.2590392f, 0.3847904f)
		            , transform.rotation);
		enemyNextGroup = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Score.Instance.current_enemies <= 0 && enemyNextGroup == 1){
			Instantiate(EnemyGroup1, new Vector3(Random.Range(1.156839f, 3.798642f), 0.2590392f, 0.3847904f)
			            , transform.rotation);
			enemyNextGroup++;
			Score.Instance.RestoreEnemies();
		}

		if(Score.Instance.current_enemies <= 0 && enemyNextGroup == 2){
			Instantiate(EnemyGroup2, new Vector3(Random.Range(-0.7225753f, 1.871042f), 6.219034f, 0)
			            , transform.rotation);
			enemyNextGroup++;
			Score.Instance.RestoreEnemies();
		}

		if(Score.Instance.current_enemies <= 0 && enemyNextGroup == 3){
			Instantiate(EnemyGroup3, new Vector3(Random.Range(-1.196269f, 1.562273f), 3.078906f, 1.537661f)
			            , transform.rotation);

			enemyNextGroup = 1;
			Score.Instance.RestoreEnemies();
		}

	}
}
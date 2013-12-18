using UnityEngine;
using System.Collections;

public class EnemyCreation : MonoBehaviour {

	public Transform EnemyGroup;

	// Use this for initialization
	void Start () {
		Instantiate(EnemyGroup, new Vector3(Random.Range(1.156839f, 3.798642f), 0.2590392f, 0.3847904f)
		            , transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(Score.Instance.current_enemies <= 0){
			Instantiate(EnemyGroup, new Vector3(Random.Range(1.156839f, 3.798642f), 0.2590392f, 0.3847904f)
			            , transform.rotation);
			Score.Instance.RestoreEnemies();
		}
	}
}

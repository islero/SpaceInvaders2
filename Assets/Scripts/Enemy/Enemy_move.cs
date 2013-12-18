using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                        Движения противников                                                   |
//+---------------------------------------------------------------------------------------------------------------+
public class Enemy_move : MonoBehaviour {

	public static float speed = 1.4f;
	private bool go_down;
	private float randMove;
	float i = 0;
	int rotate_move = 1;

	void Start(){
		go_down = false;
		randMove = Random.Range(1f, 4f);
	}

	void Update () {
		i++;

		if (i > 500){
			i = randMove * 10;
			randMove = Random.Range(1f, 4f);
		}

		transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		GameObject[] all_enemy = GameObject.FindGameObjectsWithTag("Enemy");

		if(randMove < 2f && go_down){
			go_down = false;
			foreach(GameObject selected_enemy in all_enemy){
				selected_enemy.transform.position += new Vector3(0, -0.2f, 0);
			}
		}//end if(randMove < 2f && go_down)

		if(randMove > 2f && randMove < 3f){
			go_down = false;
			foreach(GameObject selected_enemy1 in all_enemy){
				selected_enemy1.transform.position += new Vector3(0, -0.06f * Time.deltaTime, 0);
			}
		}//end if(randMove > 2f && randMove < 3f)

		if(randMove > 3f){
			go_down = false;
			if (i % 100 == 0) rotate_move *= -1;

			foreach(GameObject selected_enemy1 in all_enemy){
				selected_enemy1.transform.position += new Vector3(0, -0.03f * rotate_move * Time.deltaTime, 0);
			}
		}//end if(randMove > 3f)
		
	}//end Update()

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Right_Collider" && speed > 0){
			speed *= -1;
			go_down = true;
		}

		if(other.gameObject.name == "Left_Collider" && speed < 0){
			speed *= -1;
			go_down = true;
		}
	}

}
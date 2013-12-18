using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                Обработка попаданий пуль игрока и его противников                              |
//+---------------------------------------------------------------------------------------------------------------+
public class Bullet_destroy : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (gameObject.name == "Bullet(Clone)") {

			//---- Попадание пули игрока по противниках
				if (other.gameObject.tag == "Enemy") {
						Destroy (other.gameObject);	
		
						gameObject.GetComponentInChildren<ParticleEmitter>().Emit();
						gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX 
							| RigidbodyConstraints.FreezePositionY;
						
						gameObject.renderer.enabled = false;
						gameObject.collider.enabled = false;

						Destroy (gameObject, 0.4f);
								
				if (other.gameObject.name == "Enemy_two")
					Score.Instance.AddScore(250);
				if (other.gameObject.name == "enemy_one")
					Score.Instance.AddScore(500);

				Score.Instance.KillEnemy();
								
			}else

			//---- Попадпние пули игрока в пулю противника
			if(other.gameObject.tag == "Enemy_Bullet"){
				Destroy (other.gameObject);
				Destroy (gameObject);
			} else
			if (other.gameObject.tag != "Player") {
				Destroy(gameObject);
			}
		} else 
		{
			//---- Попадание пули противника в игрока
			if (other.gameObject.tag == "Player") {
				Score.Instance.LoseLife();

				gameObject.audio.Play();

				gameObject.GetComponentInChildren<ParticleEmitter>().Emit();
				gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX 
					| RigidbodyConstraints.FreezePositionY;
				
				gameObject.renderer.enabled = false;
				gameObject.collider.enabled = false;
				
				Destroy (gameObject, 0.5f);
			}
		}
	}
}
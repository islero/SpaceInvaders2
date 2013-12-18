using UnityEngine;
using System.Collections;
//+---------------------------------------------------------------------------------------------------------------+
//|                                Подсчет очок, жизни игрока, количества противников                             |
//|                                       И отображение информации на GUI                                         |
//+---------------------------------------------------------------------------------------------------------------+
public class Score : MonoBehaviour {
	private static Score em_Singleton;

	public static Score Instance {
		get {
			return em_Singleton;
		}
	}

	public GUISkin score_skin;
	public GUIStyle score_style;
	private int current_score;
	private int current_health;
	public int current_enemies;

	bool menuScreen;

	protected void Awake() {
		em_Singleton = this;
	}
//---- Добавление очков за убитого врага
	public void AddScore(int i){
		current_score += i;
	}
//---- Попадание противников в игрока (забирает 1 жизнь)
	public void LoseLife() {
		current_health--;
	}
//---- Попадпние игрока в противника
	public void KillEnemy(){
		current_enemies--;
	}
//---- Обновления количества врагов
	public void RestoreEnemies(){
		current_enemies = 24;
	}
	void Start(){
		current_score = 0;
		current_health = 3;
		RestoreEnemies();
		menuScreen = true;
	}

	void OnGUI () {
		GUI.skin = score_skin;
		GUI.Label (new Rect (10, 20, 1000, 50), "SCORE< " + current_score.ToString()+" >");
		GUI.Label (new Rect (10, 460, 300, 50), current_health.ToString());

		if(menuScreen){
			if (GUI.Button(new Rect (90, 190, 100, 50), "START", score_style)){
				menuScreen = false;
				Time.timeScale = 1;
			}
		}


//---- Конец игры
		if(current_health == 0){

			GUI.Label (new Rect (55, 50, 300, 50), "GAME OVER", score_style);

			int bestScore = PlayerPrefs.GetInt("BestScore", 0);

			if(bestScore < current_score){
				PlayerPrefs.SetInt("BestScore", current_score);
				bestScore = current_score;
			}

			GUI.Label (new Rect (50, 190, 300, 50), "BEST SCORE", score_style);
			GUI.Label (new Rect (50, 230, 300, 50), bestScore.ToString(), score_style);

			if (GUI.Button(new Rect (90, 350, 100, 50), "RETRY", score_style)){
				current_health = 3;
				Application.LoadLevel("Game_scene");
			}

			Time.timeScale = 0;
		}


		if(menuScreen){
			Time.timeScale = 0;
		}
	}
}
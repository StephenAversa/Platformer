using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Game master.
/// </summary>
public class GameMaster : MonoBehaviour {
	/// Points for the game
	public int points;
	/// The current wave
	public int wave;
	/// The points HUD display
	public Text pointsText;
	/// The wave HUD display
	public Text waveText;
	/// The text display for victory
	public Text winText;

	/// Reference to wave controller.
	private WaveController WaveNum;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		points = 0;
		WaveNum = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<WaveController> ();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		///Get current wave.
		wave = WaveNum.getWaveNum();
		if (pointsText != null) {
			pointsText.text = ("Score: " + points);
		}
		///Check to see if on boss wave.
		if (waveText != null) {
			if (wave <= 8){
				waveText.text = ("Wave: " + wave);
			}else{
				waveText.text = ("Wave: Boss");
			}
		}
		///Check to see if the player won the game.
		if (winText != null){
			if (wave > 9) {
				winText.text = ("You Win! \nScore: " + points);
			}
		}
	}

	/// <summary>
	/// Updates the points.
	/// </summary>
	/// <param name="p">P.</param>
	public void updatePoints(int p){
		points += p;
	}
}

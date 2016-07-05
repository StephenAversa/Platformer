using UnityEngine;
using System.Collections;
/// <summary>
/// Coin.
/// </summary>
public class Coin : MonoBehaviour {
	/// The player.
	private PlayerControl Player;
	/// The game master.
	private GameMaster gameMaster;
	/// How long the coin exists for.
	public float dissapear;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///References.
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
		dissapear = 30f;
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update(){
		dissapear -= 1 * Time.deltaTime;
		///If the timer is up, destroy the instance
		if (dissapear <= 0) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			///Update the points.
			gameMaster.updatePoints(50);
			///Destroy the object.
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Apple.
/// </summary>
public class Apple : MonoBehaviour {
	///Player character
	private PlayerControl Player;
	/// How long the apple exists for.
	public float dissapear;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///Get the player.
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		dissapear = 45f;
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
		if (col.CompareTag("Player")){
			///Add health
			Player.addHealth(1);
			///Destroy the object
			Destroy(gameObject);
		}
	}
}

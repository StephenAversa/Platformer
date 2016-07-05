using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy health manager.
/// </summary>
public class EnemyHealthManager : MonoBehaviour {
	/// The health of the enemy.
	public int health;
	/// The point value of the enemy.
	public int points;
	/// Check if damaged.
	public bool damaged;
	/// Check to see if can be damaged
	public float canDamage = 0;
	/// Invincible timer after taking damage
	public float invin = .25f;
	/// Wave object to check for total number of enemies
	private WaveController EnemyCount;
	/// Reference to game master.
	private GameMaster gameMaster;

	/// Droppable item by enemy.
	public int drop;
	/// Drop 1: Coin
	public GameObject Coin;
	/// Drop 2: Coin
	public GameObject Apple;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		damaged = false;
		EnemyCount = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<WaveController> ();
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		///Random range to change the drop
		drop = Random.Range(0, 5);
		///Check to see if the enemy is dead.
		if (health <= 0) {
			///Destroy the object.
			Destroy (this.gameObject);
			///Subtract one from global enemy count.
			EnemyCount.subtractGlobal();
			///Update the game master with the current enemy points.
			gameMaster.updatePoints(points);
			///Drop whichever drop was chosen for the enemy.
			if (drop == 0){
				if (Apple != null){
					Instantiate(Apple, transform.position, transform.rotation);
				}
			}else{
				if (Coin != null){
					Instantiate(Coin, transform.position, transform.rotation);
				}
			}

		}
	}

	/// <summary>
	/// Inflicts the damage.
	/// </summary>
	/// <param name="dmg">Dmg.</param>
	public void inflictDamage(int dmg){
		if (damaged == false && Time.time > canDamage) {
			health -= dmg;
			damaged = true;
			canDamage = Time.time + invin;
		}
	}
}

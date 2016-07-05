using UnityEngine;
using System.Collections;
/// <summary>
/// Orb spawn.
/// </summary>
public class OrbSpawn : MonoBehaviour {
	/// Seconds till the orb spawns.
	private float spawnSeconds;
	/// The orb.
	public GameObject Orb;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///Set the spawner timer.
		spawnSeconds = Random.Range(1, 30) + 75;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		spawnSeconds -= 1 * Time.deltaTime;
		Debug.Log (spawnSeconds);
		if (spawnSeconds <= 0) {
			spawnOrb();
		}
	}

	/// <summary>
	/// Spawns the orb.
	/// </summary>
	public void spawnOrb(){
		Instantiate(Orb, transform.position, transform.rotation);
		///Reset the spawn timer.
		spawnSeconds = Random.Range(1, 30) + 75;
	}
}

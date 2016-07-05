using UnityEngine;
using System.Collections;

/// <summary>
/// Wave controller.
/// </summary>
public class WaveController : MonoBehaviour {
	
	/// The wave number.
	public int waveNum;
	/// Start the next wave.
	public bool nextWave;
	/// Check to see if wave can spawn
	public bool canSpawn;
	/// Get the global enemy count.
	public int globalEnemyCount;
	/// The time between waves.
	private float seconds = 5;

	/// The index of spawner array.
	int spawnIndex;
	/// The index of the enemy array
	int enemyIndex;

	/// The spawners
	public GameObject[] Spawners;
	/// Wave 1 Enemies
	public GameObject[] Wave1;
	/// Wave 2 Enemies
	public GameObject[] Wave2;
	/// Wave 3 Enemies
	public GameObject[] Wave3;
	/// Wave 4 Enemies
	public GameObject[] Wave4;
	/// Wave 5 Enemies
	public GameObject[] Wave5;
	/// Wave 6 Enemies
	public GameObject[] Wave6;
	/// Wave 7 Enemies
	public GameObject[] Wave7;
	/// Wave 8 Enemies
	public GameObject[] Wave8;

	/// The current spawner object.
	private GameObject spawnObj;
	// The transformer reference for the spawner.
	private Transform spawner;

	/// the boss spawn object.
	public GameObject spawnBoss;
	/// The boss spawner reference.
	public Transform bossSpawner;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		//waveNum = 0;
		nextWave = true;
		canSpawn = true;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {


		///Check to see if the current wave is dead.
		if (globalEnemyCount == 0) {
			seconds -= 1 * Time.deltaTime;

			///After wave is over wait til timer is done then start next wave.
			if(seconds <= 0){
				waveNum++;
				canSpawn = true;
			}
		}
		//Debug.Log(seconds);

		///Wave number 1
		if (waveNum == 1 && canSpawn == true) {
			for(int i = 0; i < 4; i++){
				///Get a random index of enemies to choose which to spawn.
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave1.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				///Spawn the enemy
				Instantiate(Wave1[enemyIndex], spawner.position, spawner.rotation);
				///Increment the global enemy count
				globalEnemyCount++;
			}
			///Reset timer
			seconds = 5;
			///Make wave able to spawn
			canSpawn = false;

		}
		///Wave number 2
		if (waveNum == 2 && canSpawn == true) {
			for(int i = 0; i < 4; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave2.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave2[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;

		}
		///Wave number 3
		if (waveNum == 3 && canSpawn == true) {
			for(int i = 0; i < 4; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave3.Length);
				spawnObj = Spawners[spawnIndex];
				bossSpawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave3[enemyIndex], bossSpawner.position, bossSpawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;

		}
		///Wave number 4
		if (waveNum == 4 && canSpawn == true) {
			for(int i = 0; i < 6; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave4.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave4[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;
		}
		///Wave number 5
		if (waveNum == 5 && canSpawn == true) {
			for(int i = 0; i < 2; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave5.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave5[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;
			
		}
		///Wave number 6
		if (waveNum == 6 && canSpawn == true) {
			for(int i = 0; i < 6; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave6.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave6[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;
			
		}
		///Wave number 7
		if (waveNum == 7 && canSpawn == true) {
			for(int i = 0; i < 8; i++){
				spawnIndex = i;
				enemyIndex = Random.Range(0, Wave7.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave7[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 5;
			canSpawn = false;
			
		}
		///Wave number 8
		if (waveNum == 8 && canSpawn == true) {
			for(int i = 0; i < 4; i++){
				spawnIndex = Random.Range(0, Spawners.Length);
				enemyIndex = Random.Range(0, Wave8.Length);
				//Debug.Log(spawnIndex);
				spawnObj = Spawners[spawnIndex];
				spawner = spawnObj.GetComponent<Transform>();
				Instantiate(Wave8[enemyIndex], spawner.position, spawner.rotation);
				globalEnemyCount++;
			}
			seconds = 7;
			canSpawn = false;
			
		}
		///Boss
		if (waveNum == 9 && canSpawn == true) {
			Instantiate(spawnBoss, bossSpawner.position, bossSpawner.rotation);
			globalEnemyCount++;
			seconds = 5;
			canSpawn = false;
			
		}
	}
	/// <summary>
	/// Subtracts the global enemy count.
	/// </summary>
	public void subtractGlobal(){
		globalEnemyCount--;
	}
	/// <summary>
	/// Gets the wave number.
	/// </summary>
	/// <returns>The wave number.</returns>
	public int getWaveNum(){
		return waveNum;
	}
}

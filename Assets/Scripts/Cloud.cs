using UnityEngine;
using System.Collections;

/// <summary>
/// Cloud.
/// </summary>
public class Cloud : MonoBehaviour {
	///The prop that will be initiated.
	public Rigidbody2D backgroundProp;		
	/// The max leftward x coordinate of the spawn.
	public float leftSpawnPosX;	
	/// The max rightward x coordinate of the spawn.
	public float rightSpawnPosX;
	/// The lowest possible y coordinate of spawn.
	public float minSpawnPosY;
	/// The highest possible y coordinate of spawn.
	public float maxSpawnPosY;
	/// The shortest possible time between spawns.
	public float minTimeBetweenSpawns;
	/// The longest possible time between spawns.
	public float maxTimeBetweenSpawns;	
	/// The lowest possible speed of the prop.
	public float minSpeed;	
	/// The highest possible speeed of the prop.
	public float maxSpeed;					

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start ()
	{
		/// Set a Random Seed.
		Random.seed = System.DateTime.Today.Millisecond;
		
		/// Start the Spawn coroutine.
		/// A couroutine is a function that operates based on time, being able to pause and return to the function when necessary.
		StartCoroutine("Spawn");
	}
	
	
	IEnumerator Spawn ()
	{
		/// Create a random wait time before the prop is instantiated.
		float waitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
		
		/// Wait for the designated period.
		yield return new WaitForSeconds(waitTime);
		
		/// Randomly decide whether the prop should face left or right.
		bool facingLeft = Random.Range(0,2) == 0;
		
		/// If the prop is facing left, it should start on the right hand side, otherwise it should start on the left.
		float posX = facingLeft ? rightSpawnPosX : leftSpawnPosX;
		
		/// Create a random y coordinate for the prop.
		float posY = Random.Range(minSpawnPosY, maxSpawnPosY);
		
		/// Set the position the prop should spawn at.
		Vector3 spawnPos = new Vector3(posX, posY, transform.position.z);
		
		/// Instantiate the prop at the desired position.
		Rigidbody2D propInstance = Instantiate(backgroundProp, spawnPos, Quaternion.identity) as Rigidbody2D;
		
		/// If the prop is not facing left.
		if(!facingLeft)
		{
			/// Flip the scale in the x axis.
			Vector3 scale = propInstance.transform.localScale;
			scale.x *= -1;
			propInstance.transform.localScale = scale;
		}
		
		/// Create a random speed.
		float speed = Random.Range(minSpeed, maxSpeed);
		
		/// If its not facing right, reverse the speed.
		speed *= facingLeft ? -1f : 1f;
		
		/// Set the prop's velocity to this speed in the x axis.
		propInstance.velocity = new Vector2(speed, 0);
		
		/// Restart the coroutine to spawn another prop.
		StartCoroutine(Spawn());
		
		/// While the prop exists...
		while(propInstance != null)
		{
			if(facingLeft)
			{
				///If outside the box, then destroy it.
				if(propInstance.transform.position.x < leftSpawnPosX - 0.5f)
					Destroy(propInstance.gameObject);
			}
			else
			{
				///Same for the othe side.
				if(propInstance.transform.position.x > rightSpawnPosX + 0.5f)
					Destroy(propInstance.gameObject);
			}
			
			/// Return to this point after the next update.
			yield return null;
		}
	}
}
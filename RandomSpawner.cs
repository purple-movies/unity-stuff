using UnityEngine;
using System.Collections;

/**
 * Spawns one of the supplied Prefabs over a after a random time-period specified by the time-range parameters. 
 */
public class RandomSpawner : MonoBehaviour
{
	
	public GameObject[] spawns;
	public float minTime = 0;
	public float maxTime = 15;
	
	private bool validPrefabs;
	private int prefabsEndIndex = 0;
	
	
	// Use this for initialization
	void Start ()
	{
		if( spawns.Length == 0 )
		{
			validPrefabs = false;
			Debug.LogWarning( "Spawner '"+ gameObject.name +"' doesn't have any prefabs assigned to spawn!" );
		}
		else
		{
			validPrefabs = true;
			prefabsEndIndex = spawns.Length;
		}
		StartCoroutine( "spawnAfterRandomTime" );
	}
	
	// Update is called once per frame
//	void Update ()
//	{
////		Debug.Log( "RandomSpawner Update !! " );
////		maybeSpawn();
////		waitForFive();
////		StartCoroutine( "maybeSpawn" );
//	}
	
//	IEnumerator waitForFive()
//	{
//		Debug.Log ( "time :: " + Time.time.ToString() );
//		
//		yield return new WaitForSeconds( 5 );
//		
//		Debug.Log ( "time :: " + Time.time.ToString() );
//	}
	
	IEnumerator spawnAfterRandomTime()
	{
		while ( validPrefabs )
		{
			float waitTime = Random.Range( minTime, maxTime );
//			Debug.Log( "START :: " + Time.time.ToString() ); 
			
			yield return new WaitForSeconds( waitTime );
			int i = Random.Range( 0, prefabsEndIndex );
			GameObject.Instantiate(spawns[ i ]);
//			Debug.Log( "SPAWN :: " + Time.time.ToString() );
//			Debug.Log( "SPAWN :: " + i.ToString() );
		}
	}
	
}
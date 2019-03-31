using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text WinTetxt;

	public GameObject Iceberg;
	public GameObject Empty;
	public GameObject Trash;
	public GameObject Cracked;

	public float high;
	public float left;
	public int dist;

	public float spawnWait;

	void Start()
    {
		WinTetxt.text = "";
		StartCoroutine(SpawnWaves());
	}

	public void WinCondition()
	{
		//WinTetxt.text = "You Win!";
	}

	public void looseCondition()
	{
		WinTetxt.text = "You Loose!";
	}

	private void Update()
	{
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	IEnumerator SpawnWaves()
	{ 
		while (true)
		{
			for (int i = 0; i < dist; i++)
			{
				Vector3 spawnPosition = new Vector3(left, high - i, 1);
				Quaternion spawnRotation = Quaternion.identity;

				float choice = Random.Range(0, 100);

				if(choice < 20)
				{
					Instantiate(Iceberg, spawnPosition, spawnRotation);
				}
				else if(choice < 40)
				{
					Instantiate(Trash, spawnPosition, spawnRotation);
				}
				else if (choice < 60)
				{
					Instantiate(Cracked, spawnPosition, spawnRotation);
				}
				else
				{
					Instantiate(Empty, spawnPosition, spawnRotation);
				}
					
			}
			yield return new WaitForSeconds(spawnWait);
		}
	}
}

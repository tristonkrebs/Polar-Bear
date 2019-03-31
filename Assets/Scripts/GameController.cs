// Credit: Triston Krebs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text WinTetxt;

	public GameObject Iceberg;
	public GameObject Empty;

	public float high;
	public float left;
	public int dist;

	public Sprite[] sprite;

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

				if(choice < 50)
				{
					GameObject Clone = (Instantiate(Iceberg, spawnPosition, spawnRotation)) as GameObject;
					int ranInt = Random.Range(1, 5);

					if (ranInt == 1)
					{
						Clone.GetComponent<SpriteRenderer>().sprite = sprite[0];
					}
					else if (ranInt == 2)
					{
						Clone.GetComponent<SpriteRenderer>().sprite = sprite[1];
					}
					else if (ranInt == 3)
					{
						Clone.GetComponent<SpriteRenderer>().sprite = sprite[2];
					}
					else if (ranInt == 4)
					{
						Clone.GetComponent<SpriteRenderer>().sprite = sprite[3];
					}

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
// Credit: Triston Krebs
using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	public  GameObject[] downwardRocks;
	public  GameObject[] upwardRocks;
	public  GameObject[] stars;
	public  GameObject   ground1;
	public  GameObject   ground2;
	public  float        backgroundBorder;
	public  float        minTopY;
	public  float        maxTopY;
	public  float        minBottomY;
	public  float        maxBottomY;
	public  float 		 minBottomStarY;
	public  float 		 maxBottomStarY;
	public  float        groundSpeed;
	public  float        rockSpeed;
	public  float         starSpeed;
	private float        initialXPosition;

	public void Start() {
		initialXPosition = ground2.transform.position.x;
	}
	
	public void Update() {
		ground1.transform.Translate(-groundSpeed * Time.deltaTime, 0, 0);
		if (ground1.transform.position.x < 0) {
			ground1.transform.position = new Vector3(initialXPosition, ground1.transform.position.y, 0);
		}

		ground2.transform.Translate(-groundSpeed * Time.deltaTime, 0, 0);
		if (ground2.transform.position.x < 0) {
			ground2.transform.position = new Vector3(initialXPosition, ground2.transform.position.y, 0);
		}

		for (int i = 0; i < downwardRocks.Length; i++) {
			downwardRocks[i].transform.Translate(-rockSpeed * Time.deltaTime, 0, 0);
			//if (!downwardRocks[i].GetComponent<Renderer>().isVisible && downwardRocks[i].transform.position.x < 0)
			if (downwardRocks[i].transform.position.x + downwardRocks[i].transform.localScale.x < 0)
				ResetDownRock(i);
		}

		for (int i = 0; i < upwardRocks.Length; i++) {
			upwardRocks[i].transform.Translate(-rockSpeed * Time.deltaTime, 0, 0);
			//if (!upwardRocks[i].GetComponent<Renderer>().isVisible && upwardRocks[i].transform.position.x < 0)
			if (upwardRocks[i].transform.position.x + upwardRocks[i].transform.localScale.x < 0)
				ResetUpRock(i);
		}

		for (int i = 0; i < stars.Length; i++) {
			stars[i].transform.Translate(-starSpeed * Time.deltaTime, 0, 0);
			//if (!upwardRocks[i].GetComponent<Renderer>().isVisible && upwardRocks[i].transform.position.x < 0)
			if (stars[i].transform.position.x + stars[i].transform.localScale.x < 0)
				ResetStars(i);
		}



	}

	private void ResetDownRock(int i) {
		float x = UnityEngine.Random.Range(backgroundBorder, initialXPosition);
		float y = UnityEngine.Random.Range(minTopY, maxTopY);

		downwardRocks[i].transform.position = new Vector3(x, y, 0);
	}

	private void ResetUpRock(int i) {
		float x = UnityEngine.Random.Range(backgroundBorder, initialXPosition);
		float y = UnityEngine.Random.Range(minBottomY, maxBottomY);

		upwardRocks[i].transform.position = new Vector3(x, y, 0);
	}

	public void ResetStars(int i) {
		float x = UnityEngine.Random.Range(backgroundBorder, initialXPosition);
		float y = UnityEngine.Random.Range(minBottomStarY, maxBottomStarY);
		
		stars[i].transform.position = new Vector3(x, y, 0);
	}


}

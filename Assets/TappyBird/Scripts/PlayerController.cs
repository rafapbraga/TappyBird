using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {
    public  Vector2     jumpForce = new Vector2(0, 300);
	private Rigidbody2D rb;
	public Text ScoreText;
	public int ScoreNumber = 0;
	public static bool HitouStar;
	public GameObject GroundController;

	public void Start() {
		rb = GetComponent<Rigidbody2D>();
		ScoreText.text = "Score: " + ScoreNumber;
	}

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpForce);
        }

        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            Die();
    }

    public void OnTriggerEnter2D(Collider2D hit) {

		if (hit.gameObject.tag != "Stars")
        Die();

		if (hit.gameObject.tag == "Stars") {

			HitouStar = true;
			ScoreNumber += 1;
			ScoreText.text = "Score: " + ScoreNumber;
			int index = Int32.Parse(hit.name);

			GroundController.GetComponent<GroundController>().ResetStars(index);
		}



    }



    void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }
}

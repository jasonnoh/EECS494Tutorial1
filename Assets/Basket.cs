using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	// Update is called once per frame
	void Update () {
		// get screen position of the mouse
		Vector3 mousePos2D = Input.mousePosition;

		//Camera's z position sets how far to push the mouse into 3d
		mousePos2D.z = -Camera.main.transform.position.z;

		//Convert the point from 2D screen space into 3D world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		//move the x position of this basket to the x position of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}
	void Start(){
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText>();
		scoreGT.text = "0";
	}
	void OnCollisionEnter(Collision coll){
		//find out what hit this basket
		GameObject collideWith = coll.gameObject;
		if (collideWith.tag == "Apple"){
			Destroy(collideWith);
		}
		int score = int.Parse(scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString();

		if (score > HighScore.score){
			HighScore.score = score;
		}
	}
}

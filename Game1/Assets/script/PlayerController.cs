using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	public float speed;
	private Rigidbody rb;

	public Text countText;
	public Text winText;

	private int count;

	void Start () {

		rb = GetComponent<Rigidbody>();
		count = 0;
		//SetCountText();
		winText.text="";


	
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (moveHorizontal == 0 && moveVertical == 0) {
			
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("picks"))
		{
			other.gameObject.SetActive(false);
			count=count+1;
			//SetCountText();
		}
	}

}



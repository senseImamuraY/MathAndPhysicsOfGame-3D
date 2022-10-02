using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove1_1 : MonoBehaviour
{
	private Vector3 v3Position = new Vector3(0.0f, 2.0f, 0.0f);
	private Vector3 v3Velocity = new Vector3(0.2f, 0.0f, 0.0f);
	// Start is called before the first frame update
	void Start()
	{
		this.transform.position = v3Position;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void FixedUpdate()
	{
		//v3Position += v3Velocity;
		//this.transform.position = v3Position;
		transform.Translate(0.2f, 0.0f, 0.0f);
		Debug.Log(this.transform.position.x);
		if (v3Position.x > 5.0f)
		{
			v3Position.x = 5.0f;
			v3Velocity.x = -v3Velocity.x;
		}
    if (v3Position.x < -5.0f)
    {
			v3Position.x = -5.0f;
			v3Velocity.x = -v3Velocity.x;
    }
  }
}

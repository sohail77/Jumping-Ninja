using UnityEngine;
using System.Collections;

public class DMMoveObject : MonoBehaviour {
	//Distance (Position X) when current object self destroy, default value -20;
	public float distanceForSelfDestroy = -20f;
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);

		if (gameObject.transform.position.x < distanceForSelfDestroy) {
			Destroy (gameObject);
		}
	}
}

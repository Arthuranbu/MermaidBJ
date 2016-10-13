using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public Transform target;

	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, target.position.y, -10);
	}
}

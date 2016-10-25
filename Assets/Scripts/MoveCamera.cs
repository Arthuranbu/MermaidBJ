using UnityEngine;
using System.Collections;



public class MoveCamera : MonoBehaviour {
    public float maxHeight;
    public float minHeight;

    public Transform target;

	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp( target.position.y,minHeight,maxHeight), -10);
	}
}

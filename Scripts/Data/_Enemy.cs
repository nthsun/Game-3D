using UnityEngine;
using System.Collections;

[System.Serializable] 
public class _Enemy {

	public int PublicKeyToken;

	public float positionX = 0f;
	public float positionY = 0f;
	public float positionZ = 0f;

	public float rotationX = 0f;
	public float rotationY = 0f;
	public float rotationZ = 0f;

	public float scaleX = 0f;
	public float scaleY = 0f;
	public float scaleZ = 0f;


	public int currentHealth;

	public string name;

	public void setTransform(Transform transform) {
		positionX = transform.position.x;
		positionY = transform.position.y;
		positionZ = transform.position.z;

		rotationX = transform.rotation.x;
		rotationY = transform.rotation.y;
		rotationZ = transform.rotation.z;

		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;
	}
}

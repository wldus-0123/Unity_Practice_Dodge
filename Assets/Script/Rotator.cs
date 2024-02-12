using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

	private void Update()
	{
		transform.Rotate(Vector2.up, rotationSpeed*Time.deltaTime);
	}
}

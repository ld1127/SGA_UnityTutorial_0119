using System;
using System.Collections.Generic;
using UnityEngine;


class RotateModule : MonoBehaviour
{
	public float speed = 0.01f;

	private void Awake()
	{
		
	}

	private void Update()
	{
		Rotate();
	}

	void Rotate() //자전
	{
		transform.Rotate(new Vector3(0, speed, 0));
	}

}

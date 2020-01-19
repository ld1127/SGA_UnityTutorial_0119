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
		Revolute();
	}

	void Rotate() //자전
	{
		transform.Rotate(new Vector3(0, speed, 0));
	}

	void Revolute() //공전
	{
		transform.RotateAround(Vector3.zero, new Vector3(45,90,0), speed);
	}
}

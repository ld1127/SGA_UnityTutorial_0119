using System;
using System.Collections.Generic;
using UnityEngine;


class RotateModule : MonoBehaviour
{
	[SerializeField]
	GameObject target = null;
	[SerializeField]
	public float Rotationspeed = 0.01f;
	[SerializeField]
	public float Revolutespeed = 0.01f;

	private void Awake()
	{
		
	}

	private void FixedUpdate()
	{
		RevoluteCheck();
		Rotate();
	}

	void RevoluteCheck()
	{
		if (target != null)
		{
			Revolute(target.transform.position, new Vector3(0,1,0), Revolutespeed);
		}
	}

	void Rotate() //자전
	{
		transform.Rotate(new Vector3(0, Rotationspeed, 0));
	}

	void Revolute(Vector3 target, Vector3 axis, float speed) //공전
	{
		transform.RotateAround(target, axis, speed);
	}

}

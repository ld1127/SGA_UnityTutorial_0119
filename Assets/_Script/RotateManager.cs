using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateManager : MonoBehaviour
{
	[Serializable]
	public struct Planet
	{
		public string name;
		public GameObject obj;
		public float RevoluteSpeed;
		public float RotateSpeed;
		public Vector3 RevlouteAxis;
	}
	[SerializeField]
	bool isRotate = true;
	[SerializeField]
	GameObject mainAxis;
	[SerializeField]
	GameObject Sun;
	[SerializeField]
	List<Planet> planets;
	//1. struct가 아니고 Class로 하는게 더 좋았을 것인가?
	//2. Serializable과 SerializeField의 차이는? : using.System / using.UnityEngine
	//3. 코드 내에서는 리스트 정보를 알 수 없는데 이 구조가 별로인 것 같습니다. 어떻게 하는게 더 좋았을까요?

	private void Awake()
	{
		initAxis();
	}

	private void FixedUpdate()
	{
		if (isRotate)
		{
			Rotate();
			Revloute();
		}
	}

	void Update()
    {
		
	}

	void initAxis()
	{
		for (int i = 0; i < planets.Count; i++)
		{
			Planet planet = planets[i];
			planet.RevlouteAxis = RevoluteAxisCurculate(planet);

			planets[i] = planet;
		}
	}

	void Rotate()
	{
		foreach (var planet in planets)
		{
			planet.obj.transform.Rotate(0, planet.RotateSpeed, 0);
		}
	}

	void Revloute()
	{
		foreach (var planet in planets)
		{
			planet.obj.transform.RotateAround(Sun.transform.position, planet.RevlouteAxis, planet.RevoluteSpeed);
		}
	}

	Vector3 RevoluteAxisCurculate(Planet planet)
	{
		Vector3 AxisX = Sun.transform.position - planet.obj.transform.position;
		Vector3 AxisZ = mainAxis.transform.forward;

		return Vector3.Cross(AxisX, AxisZ);
	}
}

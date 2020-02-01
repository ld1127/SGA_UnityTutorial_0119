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

	//Q1. struct가 아니고 Class로 하는게 더 좋았을 것인가?
	//Q2. Serializable과 SerializeField의 차이는? : using.System / using.UnityEngine
	//Q3. 코드 내에서는 리스트 정보를 알 수 없는데 어쩔 수 없나요?

	//A1. 객체가 자주 삭제되지 않는 경우, 참조가 많은경우 -> Class / Struct 값이 자주 변동되거나 삽입 삭제가 자주 읽어나는 경우, 내부에서 값을 사용하는 경우 
	//A2. Serializable => Class / Struct / Enum / Delegate 등 하위 값이 있는 친구들을 직렬화 / SerializeField => 변수 직렬화(본인 하나)
	//A3. 

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

	public void initAxis()
	{
		//1. 반복 변수를 수정할 방법이 없는데 어떤 방법을 사용하는게 좋을까요?

		//foreach (var planet in planets)
		//{
		//	planet.RevlouteAxis = RevoluteAxisCurculate(planet.obj.transform);
		//}

		for (int i = 0; i < planets.Count; i++)
		{
			Planet planet = planets[i];
			planet.RevlouteAxis = RevoluteAxisCurculate(planet.obj.transform);
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

	Vector3 RevoluteAxisCurculate(Transform transform)
	{
		Vector3 AxisX = Sun.transform.position - transform.position;
		Vector3 AxisZ = mainAxis.transform.forward;

		return Vector3.Cross(AxisX, AxisZ);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationModule : MonoBehaviour
{
	static public Transform cubeTransform;
	delegate void RotationFunc();
	Dictionary<KeyCode, RotationFunc> keyDictionary;

	[SerializeField]
	float rotationSpeed = 0.1f;
	float MoveSpeed = 0.1f;

    void Awake()
    {
		cubeTransform = transform;
		keyDictionary = new Dictionary<KeyCode, RotationFunc>()
		{
			{ KeyCode.U, AddRotationX },
			{ KeyCode.J, SubRotationX },
			{ KeyCode.I, AddRotationY },
			{ KeyCode.K, SubRotationY },
			{ KeyCode.O, AddRotationZ },
			{ KeyCode.L, SubRotationZ },
			{ KeyCode.KeypadPlus, AddSpeed },
			{ KeyCode.KeypadMinus, SubSpeed },

			{ KeyCode.W, MoveFront },
			{ KeyCode.S, MoveBack  },
			{ KeyCode.A, MoveLeft  },
			{ KeyCode.D, MoveRight },

		};
	}

	private void FixedUpdate()
	{
		KeyCheck();
	}

	void Update()
    {
		RestrictSpeed();
	}

	//===========================================================//

	private void KeyCheck()
	{
		if (Input.anyKey)
		{
			foreach (var dic in keyDictionary)
			{
				if (Input.GetKey(dic.Key))
				{
					dic.Value();
				}
			}
		}
	}

	private void AddRotationX()
	{
		Debug.Log("RotationX+ : " + transform.rotation.x);
		transform.localEulerAngles += new Vector3(rotationSpeed, 0, 0);
	}
	private void SubRotationX()
	{
		Debug.Log("RotationX- : " + transform.rotation.x);
		transform.localEulerAngles -= new Vector3(rotationSpeed, 0, 0);
	}
	private void AddRotationY()
	{
		Debug.Log("Y+");
		transform.localEulerAngles += new Vector3(0, rotationSpeed, 0);
	}
	private void SubRotationY()
	{
		Debug.Log("Y-");
		transform.localEulerAngles -= new Vector3(0, rotationSpeed, 0);
	}
	private void AddRotationZ()
	{
		Debug.Log("Z+");
		transform.localEulerAngles += new Vector3(0, 0, rotationSpeed);
	}
	private void SubRotationZ()
	{
		Debug.Log("Z-");
		transform.localEulerAngles -= new Vector3(0, 0, rotationSpeed);
	}

	private void MoveFront()
	{
		transform.Translate(0, 0, MoveSpeed);
	}
	private void MoveBack()
	{
		transform.Translate(0, 0, -MoveSpeed);
	}
	private void MoveLeft()
	{
		transform.Translate(-MoveSpeed, 0, 0);
	}
	private void MoveRight()
	{
		transform.Translate(MoveSpeed, 0, 0);
	}

	private void AddSpeed()
	{
		rotationSpeed += 0.01f;
		MoveSpeed += 0.01f;
	}
	private void SubSpeed()
	{
		rotationSpeed -= 0.01f;
		MoveSpeed -= 0.01f;
	}

	private void RestrictSpeed()
	{
		Mathf.Clamp(rotationSpeed, 0, 100);
		Mathf.Clamp(MoveSpeed, 0, 100);
	}
}

// transform  - 본인 위치/회전/크기
// gameObject - 자기 자신 (tag, layer 등을 담고 있음.)
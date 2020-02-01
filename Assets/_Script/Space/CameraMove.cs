using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float Movespeed = 0.25f;
    [SerializeField]
    float RotationSpeed = 0.25f;

    public Transform target = null;
    //public Vector3 point = Vector3.zero;
    //public Vector3 axis = Vector3.zero;

    void Awake()
    {
        
    }

    //자주 필요한 함수의 경우 클래스를 따로 만들어서 사용해도 됨.

    void Update()
    {
        MouseMove();
        KeyInput();
    }

    void MouseMove()
    {
        mainCamera.transform.eulerAngles =
            new Vector3
            (
                -Input.mousePosition.y * RotationSpeed,
                +Input.mousePosition.x * RotationSpeed,
                +Input.mousePosition.z * RotationSpeed
            );
    }

    void KeyInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.Translate(0, 0, Movespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.Translate(0, 0, -Movespeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            mainCamera.transform.Translate(-Movespeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.Translate(Movespeed, 0, 0);
        }
    }
}


//if (target != null)
//{
//    transform.RotateAround(target.localPosition, axis, RotationSpeed);
//}
//else if (point != Vector3.zero)
//{
//    transform.RotateAround(point, axis, RotationSpeed);
//}
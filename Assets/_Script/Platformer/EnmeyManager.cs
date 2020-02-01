using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyManager : MonoBehaviour
{
    public GameObject enemyPrefab = null;
    Vector3 MousePosition;

    void Start()
    {
        
    }

    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            CreateEnemy(MousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            DeleteEnemy();
        }
    }

    void CreateEnemy(Vector3 Pos)
    {
        Instantiate(enemyPrefab, Pos, Quaternion.identity);
    }

    void DeleteEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                EnemyModule m = hit.collider.GetComponent<EnemyModule>();
                m.Death();
            }
        }
    }
}

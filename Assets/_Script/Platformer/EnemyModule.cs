using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModule : MonoBehaviour
{
    private Animator enemyAnimator;
    private bool isDead = false;

    public AnimationClip aniClip;

    void Awake()
    {
        enemyAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Death()
    {
        if (isDead) return;

        StartCoroutine(UpdateDeath());
    }

    private IEnumerator UpdateDeath()
    {
        enemyAnimator.Play("Player_Dead");
        var anime = enemyAnimator.GetCurrentAnimatorStateInfo(0).length;


        yield return new WaitForSeconds(aniClip.length);

        Destroy(gameObject);
        isDead = true;
    }
}

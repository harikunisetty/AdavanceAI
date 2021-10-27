using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,Patrol,SearchPlayer,Attack,Deffend,Panic,RunAway
    }
    public EnemyState enemyState = EnemyState.Idle;
    public bool CoroutinueStoppped = true;
    void Start()
    {
        StartCoroutine(switchEnemyState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator switchEnemyState()
    {

        yield return new WaitForSeconds(1f);

        if (CoroutinueStoppped)
            enemyState = (EnemyState)Random.Range(0f, System.Enum.GetValues(typeof(EnemyState)).Length);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(switchEnemyState());
    }
}

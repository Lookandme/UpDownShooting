using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //액션들을 만들어놓는다
    //무브먼트가 발생시 액션이 발동하도록 등록한다
    // 이벤트라는 키워드를 이용

    public event Action<Vector2> OnMoveEvent;  // action의 특징은 무조건 void만 반환 아니면 func를 사용해야한다
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;         


    //protected 프로퍼티를 하는 이유 : 나만 바꾸고 싶지만 가져가는 건 내 상속 클래스들도 볼수 있게
    protected CharacterStatsHandler stats {  get; private set; }

    private float timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking {  get; set; }
    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)  
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CollAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CollMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);  // ?. = 없으면 말고 있으면 실행한다

    }
    public void CollLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CollAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

   
   
}

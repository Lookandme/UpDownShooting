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
    public event Action OnAttackEvent;         // Attack 이벤트는 눌렀다는 사실만 중요하니까 받는 부분이 없다.

    protected bool IsAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= 0.2f)        //  <= Magic Number 수정할 예정
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking && timeSinceLastAttack > 0.2f)
        {
            timeSinceLastAttack = 0f;
            CollAttackEvent();
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
    public void CollAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

   
   
}

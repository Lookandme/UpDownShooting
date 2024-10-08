using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //�׼ǵ��� �������´�
    //�����Ʈ�� �߻��� �׼��� �ߵ��ϵ��� ����Ѵ�
    // �̺�Ʈ��� Ű���带 �̿�

    public event Action<Vector2> OnMoveEvent;  // action�� Ư¡�� ������ void�� ��ȯ �ƴϸ� func�� ����ؾ��Ѵ�
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;         // Attack �̺�Ʈ�� �����ٴ� ��Ǹ� �߿��ϴϱ� �޴� �κ��� ����.

    protected bool IsAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= 0.2f)        //  <= Magic Number ������ ����
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
        OnMoveEvent?.Invoke(direction);  // ?. = ������ ���� ������ �����Ѵ�

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

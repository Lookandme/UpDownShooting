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

    //protected ������Ƽ�� �ϴ� ���� : ���� �ٲٰ� ������ �������� �� �� ��� Ŭ�����鵵 ���� �ְ�
    protected CharacterStatsHandler stats {  get; private set; }

    private float timeSinceLastAttack = float.MaxValue;
    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)        
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
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

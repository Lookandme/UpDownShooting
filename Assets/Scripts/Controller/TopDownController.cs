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
    public event Action<AttackSO> OnAttackEvent;         


    //protected ������Ƽ�� �ϴ� ���� : ���� �ٲٰ� ������ �������� �� �� ��� Ŭ�����鵵 ���� �ְ�
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
        OnMoveEvent?.Invoke(direction);  // ?. = ������ ���� ������ �����Ѵ�

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

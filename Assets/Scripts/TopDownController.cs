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
    
    public void CollMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);  // ?. = ������ ���� ������ �����Ѵ�

    }
    public void CollLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}

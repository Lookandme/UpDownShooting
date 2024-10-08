using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    // �⺻���ݰ� ����������  ����ϴ� ������ ����
    // ������ �⺻ ���ݸ�

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat {  get; private set; }  // ���� ����

    public List<CharacterStat> StatModifiers = new List<CharacterStat>(); // �߰������� ����Ʈ�� ��Ƴ��� ����?

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        // ������ �⺻ �ɷ�ġ�� ��������� ���߿� ��ȭ �ɷ�ġ�� ������ �����ϴ�.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}
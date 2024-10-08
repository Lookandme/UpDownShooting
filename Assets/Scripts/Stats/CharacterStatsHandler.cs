using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    // 기본스텟과 최종스텟을  계산하는 로직이 들어갈것
    // 지금은 기본 스텟만

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat {  get; private set; }  // 현재 스텟

    public List<CharacterStat> StatModifiers = new List<CharacterStat>(); // 추가스텟을 리스트에 담아놓을 예정?

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
        // 지금은 기본 능력치만 적용되지만 나중에 강화 능력치도 적용이 가능하다.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}

using UnityEngine;

public enum StatsChangeType
{
    Add,     // 더해지는것  = 0
    Multiple, // 곱해지는 것 = 1
    Override // 광폭화? = 2
}
[System.Serializable]
// 데이터를 폴더처럼 사용하게 해주는 Attribute , 되게 편하다고 한다.

public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}
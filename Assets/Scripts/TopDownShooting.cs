using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;
    [SerializeField] private Transform  projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject TestPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        controller.OnAttackEvent += OnShoot;

        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        // 생성은 되지만 날아가지는 않기 때문에 날아가게 할 필요가 있음
        Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}

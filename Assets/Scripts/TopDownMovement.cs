using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 여기가 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatsHandler characterStatsHandler;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        //Awake는 주로 내 컴포넌트 안에서 끝나는 것들

        // controller랑 TopDownMovement랑 같은 게임 오브젝트에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        //fixeUpdate는 물리 업데이트에 관련이 있다.
        //Rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction) 
    {
        direction = direction * characterStatsHandler.CurrentStat.speed;
        movementRigidbody.velocity = direction;
    }

}

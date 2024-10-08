using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main; // 메인 카메라 태그가 붙어있는 카메라를 가져온다

    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CollMoveEvent(moveInput);
        // 실제 움직이는 처리는 여기서 하지 않고 PlayerMovement에서 한다
    }

    public void OnLook(InputValue value) 
    {
        Vector2 newAim = value.Get<Vector2>();  // 마우스 포지션 기준이기때문에 노말 라이징을 하지 않는다
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim); // 월드 좌표계를 가지고 온다
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CollLookEvent(newAim);
    }
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}

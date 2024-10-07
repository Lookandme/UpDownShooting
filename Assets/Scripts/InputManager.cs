using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   [SerializeField] private float speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 direction = new Vector2(horizontal, vertical);
        // ����ȭ => ���̸� 1�� ����� �۾�
        direction = direction.normalized;

        rb.velocity = direction * speed;
    }
}

using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private TopDownController controller;

    protected  virtual void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<TopDownController>();
    }
}

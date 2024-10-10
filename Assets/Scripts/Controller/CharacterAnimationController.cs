using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");


    protected override void Awake()
    {
        base.Awake();

    }
}

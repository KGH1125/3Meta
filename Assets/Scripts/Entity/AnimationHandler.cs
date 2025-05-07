using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 delta)
    {
        animator.SetBool(IsMove, delta.magnitude>0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;

    public Enemy enemy;

    public GameObject opponent;

    public float speed = 2.0f;

    public float rotSpeed = 1.0f;

    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        enemy = NPC.GetComponent<Enemy>();
    }
}

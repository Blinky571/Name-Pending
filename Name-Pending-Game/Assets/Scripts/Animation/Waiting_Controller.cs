using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting_Controller : StateMachineBehaviour
{
    private int _minWait = 1;
    private int _maxWait = 3;

    private float _waitTimer = 0;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (!animator.GetBool("isJogging"))
        {
            if (_waitTimer <= 0)
            {
                Waiting(animator);
                _waitTimer = Random.Range(_minWait, _maxWait);
            }
            else if (animator.GetBool("isWaiting") == false)
            {
                _waitTimer -= Time.deltaTime;
            }
        }
    }

    void Waiting(Animator animator)
    {
        animator.SetBool("isWaiting", true);
    }
}

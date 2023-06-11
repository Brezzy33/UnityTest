using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator;
    private int isWalkingHash;
    private int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwarPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //if playes press w key
        if (!isWalking && forwarPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        //if player is not pressing w key
        if (isWalking && !forwarPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if player is walking and not running and presses left shift
        if (!isRunning && (forwarPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        //if player is running and stops running or stops walking
        if (isRunning && (!forwarPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}

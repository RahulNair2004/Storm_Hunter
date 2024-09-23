using UnityEngine;

public class PlaySequentialAnimations : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Start the first animation
        animator.Play("Circular");
    }

    void Update()
    {
        // Check if the first animation has finished
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Circular") && stateInfo.normalizedTime >= 1.0f)
        {
            // Trigger the second animation
            animator.SetTrigger("Victory 2");
        }
    }
}

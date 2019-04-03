using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public CharacterController player;
    public Transform playerTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidade", player.velocity.magnitude);

        if (playerTransform.position.y > 0.7) {
            animator.SetBool("pulando",true);
        } else {
            animator.SetBool("pulando", false);
        }
    }
}

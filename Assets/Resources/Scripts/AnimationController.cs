using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//You don't need to worry about this script,
//it deals with all the animations taken from the player controller
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour //Mario's code
{
    public ParticleSystem dust;


    private PlayerController m_playerController;
    private Animator m_animator;
    void Start()
    {
        m_playerController = GetComponent<PlayerController>();
        m_animator = GetComponent<Animator>();
        m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/_MarioAnimator");
        transform.gameObject.layer = 3;
        m_playerController.GroundLayer = LayerMask.GetMask("Default");
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {
        //Plays jump animation
        if (!m_playerController.m_grounded)
        {
            m_animator.SetBool("Jump", true);

        }
        else
        {
            m_animator.SetBool("Jump", false);
        }

        //Plays walking animation
        if (m_playerController.m_horizontalMovement.x != 0)
        {
            if (m_playerController.m_grounded)
            {
                //CreateDust(); //this dust effect breaks after jumping to the left/right
            }
            m_animator.SetBool("Run", true);
        }
        else
        {
            m_animator.SetBool("Run", false);
        }

        //Flips the player in the right direction
        if (m_playerController.m_horizontalMovement.x > 0)
        {
            m_playerController.transform.localScale = new Vector3(1, 1, 1);
            dust.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (m_playerController.m_horizontalMovement.x < 0)
        {
            m_playerController.transform.localScale = new Vector3(-1, 1, 1);
            dust.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}

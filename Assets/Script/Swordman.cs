using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swordman : PlayerController
{
    public GameObject Camera;
    private void Start()
    {
        m_CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        checkInput();

        if (m_rigidbody.velocity.magnitude > 30)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);
        }
    }
    public void checkInput()
    {
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, -2);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IsSit = true;
            m_Anim.Play("Sit");
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            m_Anim.Play("Idle");
            IsSit = false;
        }

        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJumpCount < JumpCount)
                {
                    DownJump();
                }
            }
            return;
        }

        m_MoveX = Input.GetAxis("Horizontal");

        GroundCheckUpdate();

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Object.FindObjectOfType<AudioManager>().Play("Sword");
                m_Anim.Play("Attack");
            }
            else
            {
                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                        m_Anim.Play("Idle");
                }
                else
                {
                    m_Anim.Play("Run");
                }
            }
        }


        /*   if (Input.GetKey(KeyCode.Alpha1))
           {
               m_Anim.Play("Die");
           }
        */

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isGrounded)
            {
                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
            }

            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.RightArrow))
                Filp(false);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (isGrounded)
                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

            transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
        }

        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        if (!Input.GetKey(KeyCode.LeftArrow))
            Filp(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Object.FindObjectOfType<AudioManager>().Play("Jump");
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (currentJumpCount < JumpCount)
            {
                if (!IsSit)
                {
                    prefromJump();
                }
                else
                {
                    DownJump();
                }
            }
        }
    }

    protected override void LandingEvent()
    {
        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");
    }

}

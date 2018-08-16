using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

public float m_RunSpeed;
public float m_MaxSpeed;
private Animator m_PlayerAnimator;
private SpriteRenderer m_PlayerSprRend;
private Rigidbody2D m_RB2D;

	// Use this for initialization
	void Start () 
	{
		m_PlayerAnimator = gameObject.GetComponent<Animator>();
		m_PlayerSprRend = gameObject.GetComponent<SpriteRenderer>();
		m_RB2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(m_RB2D.velocity.magnitude);
		InputCheck();


	}

	private void InputCheck()
	{
		if(Input.GetKey(KeyCode.D))
		{
			m_RB2D.AddForce((Vector2.right.normalized * m_RunSpeed), ForceMode2D.Force);
			if(m_RB2D.velocity.magnitude > m_MaxSpeed)
			{
				float diff = m_RB2D.velocity.magnitude - m_MaxSpeed;
				m_RB2D.AddForce((-m_RB2D.velocity.normalized * diff), ForceMode2D.Force);
			}
			m_PlayerAnimator.SetBool("isRunning", true);
			m_PlayerSprRend.flipX = false;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			m_RB2D.AddForce((Vector2.left.normalized * m_RunSpeed), ForceMode2D.Force);
			if(m_RB2D.velocity.magnitude > m_MaxSpeed)
			{
				float diff = m_RB2D.velocity.magnitude - m_MaxSpeed;
				m_RB2D.AddForce((-m_RB2D.velocity.normalized * diff), ForceMode2D.Force);
			}
			m_PlayerAnimator.SetBool("isRunning", true);
			m_PlayerSprRend.flipX = true;
		}
		else
		{
			m_PlayerAnimator.SetBool("isRunning", false);
		}
	}
}

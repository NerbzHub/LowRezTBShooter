using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrler : MonoBehaviour
{

public float m_RunSpeed;
public float m_MaxSpeed;
public float m_Downforce;
public float m_JumpForce;
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
		//Debug.Log(m_RB2D.velocity.magnitude);
		InputCheck();
		PushDown();
		
	}

	private void InputCheck()
	{
		if(Input.GetKey(KeyCode.D))
		{
			m_RB2D.AddForce((gameObject.transform.right.normalized * m_RunSpeed), ForceMode2D.Force);
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
			m_RB2D.AddForce((-gameObject.transform.right.normalized * m_RunSpeed), ForceMode2D.Force);
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

		if(Input.GetKeyDown(KeyCode.Space))
		{
			m_RB2D.AddForce(gameObject.transform.up.normalized * m_JumpForce, ForceMode2D.Impulse);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	private void PushDown()
	{
		m_RB2D.AddForce((new Vector2(gameObject.transform.up.x * -1, gameObject.transform.up.y * -1).normalized * m_Downforce));
	}

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

private Animator m_PlayerAnimator;
private SpriteRenderer m_PlayerSprRend;
	// Use this for initialization
	void Start () 
	{
		m_PlayerAnimator = gameObject.GetComponent<Animator>();
		m_PlayerSprRend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.D))
		{
			m_PlayerAnimator.SetBool("isRunning", true);
			m_PlayerSprRend.flipX = false;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			m_PlayerAnimator.SetBool("isRunning", true);
			m_PlayerSprRend.flipX = true;
		}
		else
		{
			m_PlayerAnimator.SetBool("isRunning", false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomiser : MonoBehaviour {

	// Array of background images.
	public Sprite[] m_Background;

	// To cache the sprite renderer.
	private SpriteRenderer m_SpriteRenderer;

	// Use this for initialization
	void Start () 
	{
		m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		m_SpriteRenderer.sprite = m_Background[RandomNum()];
		m_SpriteRenderer.flipX = RandomBool();
	}

	// Spits out a random int between 0 and the size of the background array.
	private int RandomNum()
	{
		int rand = Random.Range(0, m_Background.Length);
		return rand;
	}

	// Spits out a random boolean value.
	private bool RandomBool()
	{
		int rand = Random.Range(0,2);

		if(rand == 0)
			return false;
		else
			return true;
	}
}

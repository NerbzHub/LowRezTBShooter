using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerNetworkLoad : MonoBehaviour {

	private GameObject m_Player = null;

	public string m_PrefabName;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!m_Player)
            {
                if (m_Player = GameObject.Find(m_PrefabName + "(Clone)"))
                {
					Debug.Log("Hit");
                    m_Player.GetComponent<PlayerCtrler>().enabled = true;
                }
            }
	}
}

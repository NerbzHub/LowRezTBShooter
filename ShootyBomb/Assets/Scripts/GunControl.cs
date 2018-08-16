using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public GameObject m_Bullet;
	public GameObject m_ShootPoint;
	public Camera m_MainCam;
	public float m_ShootPower;
	private Vector3 m_MousePos;
	private Vector3 m_ObjectPos;
	private float m_GunAngle;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		CalcRotation();
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
	}

	// Was struggling to get the rotation of the gun right.
	// https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
	// This forum post helped me out.
	private void CalcRotation()
	{
		
         m_MousePos = Input.mousePosition;
         m_MousePos.z = 5.23f;
 
         m_ObjectPos = m_MainCam.WorldToScreenPoint (transform.position);
         m_MousePos.x = m_MousePos.x - m_ObjectPos.x;
         m_MousePos.y = m_MousePos.y - m_ObjectPos.y;
 
         m_GunAngle = Mathf.Atan2(m_MousePos.y, m_MousePos.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, m_GunAngle));
	}

	private void Shoot()
	{
		GameObject bullet = GameObject.Instantiate(m_Bullet, m_ShootPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, m_GunAngle)));

		bullet.GetComponent<Rigidbody2D>().AddForce((new Vector2(m_MousePos.x, m_MousePos.y).normalized * m_ShootPower), ForceMode2D.Impulse);

	}
}

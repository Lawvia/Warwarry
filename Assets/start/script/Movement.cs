using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public int m_PlayerNumber = 1;              // tank id, utk player 1 atau 2
	public float m_Speed = 12f;                 // speed parameter dari tank
	public float m_TurnSpeed = 180f;            // speed belok
	public AudioSource m_MovementAudio;         
	public AudioClip m_EngineIdling;            
	public AudioClip m_EngineDriving;           
	public float m_PitchRange = 0.2f;           


	private string m_MovementAxisName;          // untuk input axis , maju dan mundur
	private string m_TurnAxisName;              // untuk belok
	private Rigidbody m_Rigidbody;              
	private float m_MovementInputValue;         // utk store current input pada move
	private float m_TurnInputValue;             // utk store current input pada belok
	private float m_OriginalPitch;              


	private void Awake ()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();
	}


	private void OnEnable ()
	{
		
		m_Rigidbody.isKinematic = false;

		
		m_MovementInputValue = 0f;
		m_TurnInputValue = 0f;
	}


	private void OnDisable ()
	{
		// utk set kindematic stop jika tank not moving
		m_Rigidbody.isKinematic = true;
	}


	private void Start ()
	{
		
		m_MovementAxisName = "Vertical" + m_PlayerNumber;
		m_TurnAxisName = "Horizontal" + m_PlayerNumber;

		
		m_OriginalPitch = m_MovementAudio.pitch;
	}


	private void Update ()
	{
		// store value dari input axis
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		EngineAudio ();
	}


	private void EngineAudio ()
	{
		// if player diam, no input..
		if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f)
		{
			// ... and if audio skrg lagi play "driving" maka ganti ke idle sound
			if (m_MovementAudio.clip == m_EngineDriving)
			{
				
				m_MovementAudio.clip = m_EngineIdling;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play ();
			}
		}
		else
		{
			// kalau tank moving dan audio masih idel, change ke driving audio
			if (m_MovementAudio.clip == m_EngineIdling)
			{
				
				m_MovementAudio.clip = m_EngineDriving;
				m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play();
			}
		}
	}


	private void FixedUpdate ()
	{
		
		Move ();
		Turn ();
	}


	private void Move ()
	{
		// rumus untuk tank moving dari tutorial
		Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

		// apply ini ke rigidbody pos.
		m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
	}


	private void Turn ()
	{
		
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}
}
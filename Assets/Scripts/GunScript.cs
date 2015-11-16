﻿using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	
	public Transform 	bulletSpawnPosition;
	public float 		raycastDistance = 50;
	public Color		raycastColor = Color.yellow;
	public float		raycastDuration = 0.5f;
	
	
	private Ray 		raycast;
	private RaycastHit 	raycastHit;
	private float 		raycastRealDistance;
	
	//remember:
	//tracer enabled by design on ALL weapons (might want to change that)
	private LineRenderer tracer;
	public AudioSource  gunSound;
	public Rigidbody shell;
	public Rigidbody bullet;
	public Transform shellEjectionPoint;
	public Transform rifleEndPoint;

	public void Start(){
		raycastRealDistance = raycastDistance;
		tracer = GetComponent<LineRenderer>();
		//gunSound = GetComponent<AudioSource>();
	}

	public void Shoot(){
		
		raycast = new Ray(bulletSpawnPosition.position, bulletSpawnPosition.forward);
		
		if(Physics.Raycast(raycast, out raycastHit, raycastDistance)) raycastRealDistance = raycastHit.distance;
			else raycastRealDistance = raycastDistance;
		
		gunSound.Play();
		StartCoroutine("RenderTracer");
		//Debug.DrawRay(raycast.origin, raycast.direction * raycastDistance, raycastColor, raycastDuration);
		
		Rigidbody newShell = Instantiate(shell, shellEjectionPoint.position, Quaternion.identity) as Rigidbody;
		newShell.AddForce(shellEjectionPoint.forward * Random.Range(90f, 290f) + bulletSpawnPosition.forward * Random.Range(-5f, 8f));
		
		Rigidbody shellFX = Instantiate(bullet, rifleEndPoint.position, Quaternion.identity) as Rigidbody;
		shellFX.AddForce(rifleEndPoint.forward * 1000f);
		
		
	}
	
	IEnumerator RenderTracer() {
		tracer.enabled = true;
		tracer.SetPosition(0, bulletSpawnPosition.position);
		tracer.SetPosition(1, bulletSpawnPosition.position + raycast.direction * raycastRealDistance);
		yield return null;
		tracer.enabled = false;
	}
	
}

using UnityEngine;
using System.Collections;

public class ParticleSystemTap : MonoBehaviour {

	private ParticleSystem system;
	private bool initialized = false;
		
	void Start () {
		system = GetComponent<ParticleSystem>();
		initialized = (system != null);
		
	 	if (system) system.Stop();
	}
	
	void Update () {
	}
	
	public void Play()
	{
		if (initialized)
			system.Emit(1);
	}
}

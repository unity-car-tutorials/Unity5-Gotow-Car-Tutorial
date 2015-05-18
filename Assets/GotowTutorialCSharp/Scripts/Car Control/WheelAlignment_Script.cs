// the visible wheel, the slip prefab is the prefab instantiated when the wheels slide, the rotation value is the
// value used to rotate the wheel around it's axel.

using UnityEngine;
using System.Collections;

public class WheelAlignment_Script : MonoBehaviour {

	public WheelCollider CorrespondingCollider;
	public GameObject tapObject;
	private ParticleSystemTap tap;
	
	void Awake()
	{
		tap = tapObject.GetComponent<ParticleSystemTap>();
	}
	
	void Update (){
				
		Quaternion rotation;
		Vector3 position;
		
		CorrespondingCollider.GetWorldPose (out position, out rotation);
		
		transform.position = position;
		transform.rotation = rotation;
	
		WheelHit CorrespondingGroundHit;
		CorrespondingCollider.GetGroundHit(out CorrespondingGroundHit );
		
		// if the slip of the tire is greater than 0.1f, and the slip prefab exists, create an instance of it on the ground at
		// a zero rotation.
		if ( Mathf.Abs( CorrespondingGroundHit.sidewaysSlip ) > 0.1f ) {
			if (tap != null) {
				// CorrespondingGroundHit.point stores the point where particles can be emitted
				tap.Play();
			}
		}
		
	}
}
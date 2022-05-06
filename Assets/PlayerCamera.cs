using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public Transform CameraTarget;
	public Rigidbody TargetRigidBody;

	private void LateUpdate()
	{
		if (CameraTarget == null || this.TargetRigidBody == null)
		{
			return;
		}

		Vector3 targetPosition = CameraTarget.position;
		targetPosition.y = Mathf.Max(targetPosition.y, 0f);
		transform.position = targetPosition;
		var rot = transform.rotation;
		transform.LookAt(targetPosition+this.TargetRigidBody.velocity);
		transform.rotation = Quaternion.Lerp(rot, transform.rotation, 0.1f * Time.deltaTime);

		//Vector3 direction = new Vector3(this.TargetRigidBody.velocity.x, 0f, this.TargetRigidBody.velocity.z);// Point - transform.position;
		//Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
		//transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.01f * Time.time);

	}
}
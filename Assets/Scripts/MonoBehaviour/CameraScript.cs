using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform CameraTarget;
    private Rigidbody2D targetRigidbody2D;

    private Vector2 distanceToTarget;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float maxDistanceToTarget = 10f;
    [SerializeField]
    private float dampTime = 0.15f;


    private void Start()
    {
        if (CameraTarget != null)
        {

            targetRigidbody2D = CameraTarget.GetComponent<Rigidbody2D>();

        }


    }

    private void FixedUpdate()
    {


        distanceToTarget = Vector2.ClampMagnitude(targetRigidbody2D.velocity, maxDistanceToTarget);

        targetPosition = new Vector3(CameraTarget.position.x + distanceToTarget.x, CameraTarget.position.y + distanceToTarget.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dampTime);


    }


}

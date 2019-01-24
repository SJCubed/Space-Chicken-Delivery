using UnityEngine;

[RequireComponent(typeof(ShipEngine))]
[RequireComponent(typeof(ShipRotation))]
public class PlayerMovementInputController : MonoBehaviour
{
    public ShipMovementStats movementStats;
    private ShipEngine shipEngine;
    private ShipRotation shipRotation;
    private Vector2 targetPosition;
    private float thrust;
    private float maxSpeed;
    private float brake;
    private float rotation;

    private void Awake()
    {
        shipEngine = GetComponent<ShipEngine>();
        shipRotation = GetComponent<ShipRotation>();
    }

    private void Update()
    {
        thrust = Input.GetAxis("Thrust") * movementStats.Thrust;
        brake = Input.GetAxis("Brake") * movementStats.Brake;
        rotation = movementStats.Rotation;
        maxSpeed = movementStats.MaxSpeed;

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        shipEngine.EngineThrust(thrust);
        shipEngine.EngineBrake(brake);
        shipRotation.ShipRotate(targetPosition, rotation);
        shipEngine.EngineMaxSpeed(maxSpeed);
    }

}

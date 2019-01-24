using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    private Rigidbody2D myRB2D;

    private void Awake()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    public void EngineThrust(float thrust)
    {
        myRB2D.AddRelativeForce(Vector2.up * thrust);
    }

    public void EngineBrake(float brake)
    {
        if (myRB2D.velocity.magnitude >= brake / 2)
            myRB2D.AddForce(-Vector2.ClampMagnitude(myRB2D.velocity, brake));
        else
            myRB2D.velocity = Vector2.zero;
    }

    public void EngineMaxSpeed(float maxSpeed)
    {
        myRB2D.velocity = Vector2.ClampMagnitude(myRB2D.velocity, maxSpeed);
    }

}

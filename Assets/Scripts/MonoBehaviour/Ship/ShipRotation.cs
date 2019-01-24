using UnityEngine;

public class ShipRotation : MonoBehaviour
{

    public void ShipRotate(Vector2 targetPosition, float rotation)
    {
        Quaternion q = Quaternion.AngleAxis((Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg) - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotation * Time.deltaTime);
    }

}

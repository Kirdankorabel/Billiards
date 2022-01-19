using UnityEngine;

public static class CollisionsCalculator
{
    public static Vector3 WallsCollision(Vector3 direction, Rigidbody rigidbody, Vector3 collisionPosition)
    {
        if (direction.x >= 0 && direction.z >= 0)
        {
            if (!calculateWallBounce(Vector3.right, ref direction, collisionPosition))
                calculateWallBounce(Vector3.forward, ref direction, collisionPosition);
        }
        else if (direction.x <= 0 && direction.z >= 0)
        {
            if (!calculateWallBounce(Vector3.left, ref direction, collisionPosition))
                calculateWallBounce(Vector3.forward, ref direction, collisionPosition);
        }
        else if (direction.x >= 0 && direction.z <= 0)
        {
            if (!calculateWallBounce(Vector3.back,ref direction, collisionPosition))
                calculateWallBounce(Vector3.right, ref direction, collisionPosition);
        }
        else if (direction.x <= 0 && direction.z <= 0)
        {
            if (!calculateWallBounce(Vector3.back, ref direction, collisionPosition))
                calculateWallBounce(Vector3.left, ref direction, collisionPosition);
        }
        rigidbody.velocity = rigidbody.velocity.magnitude * direction;
        return direction;
    }

    private static bool calculateWallBounce(Vector3 dir, ref Vector3 direction, Vector3 collisionPosition)
    {
        RaycastHit hit;
        Physics.Raycast(collisionPosition, dir, out hit);
        if (hit.distance < 0.6f)
        {
            direction = Vector3.Reflect(direction, dir);
            return true;
        }
        return false;
    }
}

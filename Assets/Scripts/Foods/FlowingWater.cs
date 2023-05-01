using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingWater : MonoBehaviour
{
    [SerializeField] Vector2 forceToApply;
    [SerializeField] float maxSpeed;

    private Collider2D myCollider;
    private ContactFilter2D noFilter;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        noFilter = new ContactFilter2D();
        noFilter.NoFilter();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        FloatOnWater floatOnWater = collision.gameObject.GetComponent<FloatOnWater>();
        if (floatOnWater)
        {
            float collidedHeight = collision.bounds.size.y;

            Vector2 topMiddle = (Vector2)collision.bounds.center + new Vector2(0f,  0.5f * collidedHeight);

            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(topMiddle, new Vector2(0f, -1f), noFilter, results, collidedHeight);

            foreach (var result in results)
            {
                if (result.collider != myCollider)
                {
                    continue;
                }
                
                float propSubmerged = Mathf.Clamp(1f - result.distance / collidedHeight, 0f, 1f);

                collision.attachedRigidbody.AddForce(forceToApply * propSubmerged);
                float speed = collision.attachedRigidbody.velocity.magnitude;
                if (speed >= maxSpeed)
                {
                    collision.attachedRigidbody.velocity *= maxSpeed / speed;
                }

                /*
                Vector2 forceDir = forceToApply.normalized;
                float velocityInForceDir = Vector2.Dot(forceDir, collision.attachedRigidbody.velocity);
                float speedInForceDir = Mathf.Abs(velocityInForceDir);
                if (speedInForceDir >= maxSpeed)
                {
                    float speedChange = speedInForceDir - maxSpeed;
                    float velocitySign = velocityInForceDir / speedInForceDir;
                    collision.attachedRigidbody.velocity -= speedChange * velocitySign * forceDir;
                }
                */
            }
        }
    }
}

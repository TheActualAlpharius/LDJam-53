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

                float propSubmerged = 1f - result.distance / collidedHeight;

                collision.attachedRigidbody.AddForce(forceToApply * propSubmerged);
                if (collision.attachedRigidbody.velocity.magnitude >= maxSpeed)
                {
                    collision.attachedRigidbody.velocity *= maxSpeed / collision.attachedRigidbody.velocity.magnitude;
                }
            }
            /* A MUCH WORSE BUT FASTER ALTERNATIVE
            ColliderDistance2D distanceToSeparate = Physics2D.Distance(GetComponent<Collider2D>(), collision);

            // Either of these would be weird as we've detected a collision, may as well check though.
            if (!distanceToSeparate.isValid || distanceToSeparate.distance > 0f)
            {
                return;
            }

            float inclination = Vector2.Dot(distanceToSeparate.normal, new Vector2(0f, 1f));

            float propSubmerged;
            if (inclination > 0f) // We're closest to the surface of the water
            {
                // Get the distance to it
                float distanceToSurface = -distanceToSeparate.distance * inclination;
                propSubmerged = Mathf.Min(1f, distanceToSurface / collision.bounds.size.y);
            }
            else // We're not closest to the surface, just assume we're fully submerged (we should be unless the water is very thin)
            {
                propSubmerged = 1f;
            }
            */
        }
    }
}

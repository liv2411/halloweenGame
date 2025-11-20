using UnityEngine;
using System.Collections;

public class RoamingBehavior : MonoBehaviour
{
    public float roamRadius = 10f;
    public float roamSpeed = 2f;
    public float waitTime = 2f;

    // Initialize allows chained call from AddComponent(...).Initialize(...)
    public RoamingBehavior Initialize(float radius, float speed, float wait)
    {
        roamRadius = radius;
        roamSpeed = speed;
        waitTime = wait;
        // start roaming behavior
        StartCoroutine(Roam());
        return this;
    }

    IEnumerator Roam()
    {
        Vector3 origin = transform.position;
        while (true)
        {
            // pick a random point within a circle on the XZ plane
            Vector2 rand = Random.insideUnitCircle * roamRadius;
            Vector3 target = origin + new Vector3(rand.x, 0f, rand.y);

            // Move towards target
            while (Vector3.Distance(transform.position, target) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, roamSpeed * Time.deltaTime);
                yield return null;
            }

            // Wait, then pick a new target
            yield return new WaitForSeconds(waitTime);
        }
    }
}

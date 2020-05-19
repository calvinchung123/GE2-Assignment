using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scontroller : MonoBehaviour
{
    Animator anim;

    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;

    public float mass = 1.0f;

    public float maxSpeed = 5;
    public float maxForce = 10;

    public float speed = 0;

    public bool seekEnabled = false;
    public Vector3 target;
    public Transform targetTransform;

    public bool arriveEnabled = false;
    public float slowingDistance = 10;

    public float maxAngle;
    public float maxRadius;
    public Transform enemy;

    private bool isinFOV = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }
    Vector3 Arrive(Vector3 target)
    {

        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;

        float ramped = (dist / slowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = (toTarget / dist) * clamped;

        return desired - velocity;
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(target);

        }
        if (arriveEnabled)
        {
            force += Arrive(target);
        }
        return force;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovline1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovline2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovline1);
        Gizmos.DrawRay(transform.position, fovline2);

        if (!isinFOV)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (enemy.position - transform.position).normalized * maxRadius);

        //Gizmos.color = Color.black;
        //Gizmos.DrawRay(transform.position, transform.forward * maxRadius);

    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                                return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            target = targetTransform.position;
            anim.SetInteger("Condition", 1);
        }
  
        force = CalculateForce();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
        speed = velocity.magnitude;
        transform.LookAt(target);
        isinFOV = inFOV(transform, enemy, maxAngle, maxRadius);

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Security.Cryptography;
using UnityEngine;

public class fieldofview : MonoBehaviour
{
    Animator anim;
    public static float maxAngle;
    public static float maxRadius;
    public Transform enemy;

    private bool isinFOV = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        if(!isinFOV)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (enemy.position - transform.position).normalized *maxRadius);

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

                    if(angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if(Physics.Raycast(ray, out hit, maxRadius))
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
        isinFOV = inFOV(transform, enemy, maxAngle, maxRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShootingRay : MonoBehaviour
{
    public static ActivateShootingRay instance;

    Vector3 BigScale = new Vector3(136.90f, 0.39f, 1);
    Vector3 SmallScale = new Vector3(136.90f, 0.1f, 1);

    public float WindUpTime = 1;
    public float duration = 0.5f;

    public bool isShootingRayActivated;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        transform.localScale = SmallScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShootingRayActivated)
        {
            StartCoroutine(ShootingRayWindUp(WindUpTime, duration));
        }
    }

    IEnumerator ShootingRayWindUp(float WindUpTime, float duration)
    {
        yield return new WaitForSeconds(WindUpTime);
        transform.localScale = BigScale;
        gameObject.tag = "Projectile";
        yield return new WaitForSeconds(duration);
        transform.localScale = SmallScale;
        gameObject.tag = "Untagged";
        isShootingRayActivated = false;
    }
}

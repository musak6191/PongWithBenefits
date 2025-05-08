using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShootingRay : MonoBehaviour
{

    public Vector3 BigScale = new Vector3(136.90f, 0.39f, 1);
    public Vector3 SmallScale = new Vector3(136.90f, 0.1f, 1);

    public float WindUpTime = 1;
    public float duration = 0.5f;

    //public bool isShootingRayAlreadyActive;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = SmallScale;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (isShootingRayAlreadyActive)
        //{
        //    ActivateAndPlayShootingRayCoroutine();
        //}
    }

    //void ActivateAndPlayShootingRayCoroutine()
    //{
    //    gameObject.SetActive(true);
    //    StartCoroutine(ShootingRayWindUp(WindUpTime, duration));
    //}
    //IEnumerator ShootingRayWindUp(float WindUpTime, float duration)
    //{
    //    if (isShootingRayAlreadyActive)
    //    {
    //        isShootingRayAlreadyActive = false;
    //        yield return new WaitForSeconds(WindUpTime);
    //        transform.localScale = BigScale;
    //        gameObject.tag = "Projectile";
    //        yield return new WaitForSeconds(duration);
    //        transform.localScale = SmallScale;
    //        gameObject.tag = "Untagged";
    //        gameObject.SetActive(false);
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShootingRay : MonoBehaviour
{

    public Vector3 BigScale = new Vector3(136.90f, 0.39f, 1);
    public Vector3 SmallScale = new Vector3(136.90f, 0.1f, 1);

    public float WindUpTime = 1;
    public float duration = 0.5f;

    void Start()
    {
        transform.localScale = SmallScale;
        gameObject.SetActive(false);
    }
}

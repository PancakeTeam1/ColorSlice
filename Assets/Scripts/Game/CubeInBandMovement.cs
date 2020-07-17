using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInBandMovement : MonoBehaviour
{
    public float speed = 15f;
    private BandGenerator generator;

    private void Start()
    {
        generator = transform.parent.GetComponent<BandGenerator>();
    }

    private void Update()
    {
        Vector3 changed = (generator.endPoint - generator.startPoint).normalized * speed * Time.deltaTime;
        transform.Translate(changed);
        if ((transform.position - generator.startPoint).sqrMagnitude >= (generator.endPoint - generator.startPoint).sqrMagnitude)
        {
            gameObject.SetActive(false);
        }
    }
}

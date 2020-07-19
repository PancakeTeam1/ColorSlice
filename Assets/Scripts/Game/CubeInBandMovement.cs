using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInBandMovement : MonoBehaviour
{
    public float speed = 15f;
    private BandGenerator generator;
    private CubeToCanvasMovement movement;

    private void Start()
    {
        generator = transform.parent.GetComponent<BandGenerator>();
    }

    private void Update()
    {
        Vector3 changed = (generator.endPoint.localPosition - generator.startPoint.localPosition).normalized * speed * Time.deltaTime;
        transform.Translate(changed);
        if ((transform.localPosition - generator.startPoint.localPosition).sqrMagnitude >= (generator.endPoint.localPosition - generator.startPoint.localPosition).sqrMagnitude)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnHitbuttonClick()
    {
        if(this.transform.position.x >= Camera.main.transform.position.x-0.5f && this.transform.position.x <= Camera.main.transform.position.x + 0.5f)
        {
            movement.statement = true;
            movement.place = Camera.main.transform.position;
        }
    }
}

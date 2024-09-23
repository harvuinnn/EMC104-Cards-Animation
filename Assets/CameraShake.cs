using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 0.2f;
    public float shakeMagnitude = 0.5f; 

    private void OnMouseDown()
    {
        StartCoroutine(Shaking());
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float shakeOffsetY = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(startPosition.x, startPosition.y + shakeOffsetY, startPosition.z);

            float strength = curve.Evaluate(elapsedTime / duration);
            yield return null;
        }

        transform.position = startPosition;
    }
}

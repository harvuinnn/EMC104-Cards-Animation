using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField]
    private Sprite frontFace, backFace;

    private bool coroutineAllowed, facedUp;

    private CameraShake cameraShake;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = backFace;
        coroutineAllowed = true;
        facedUp = false;

        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shaking());
        }

        if (!facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    rend.sprite = frontFace;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    rend.sprite = backFace;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;
        facedUp = !facedUp;
    }
}

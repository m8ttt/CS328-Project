using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invis : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isHidden = false;

    public float invisibilityDuration = 3f;
    public float visibilityDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibilityRoutine());
    }

    IEnumerator ToggleVisibilityRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(invisibilityDuration);

            isHidden = !isHidden;
            spriteRenderer.enabled = !isHidden;

            yield return new WaitForSeconds(visibilityDuration);
        }
    }
}


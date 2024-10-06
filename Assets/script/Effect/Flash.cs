using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material whiteFlashmat;
    [SerializeField] private float restoreDefaulMatTime = .2f;
    private Material defaultMat;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }
    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = whiteFlashmat;
        yield return new WaitForSeconds(restoreDefaulMatTime);
        spriteRenderer.material = defaultMat;
    }
}

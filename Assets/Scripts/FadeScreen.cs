using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool FadeOnStart = true;
    public float FadeDuration = 2;
    private bool _hasFaded = false;

    private Color _fadeColor = Color.black;
    private Renderer _renderer;


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (FadeOnStart) FadeIn();
    }

    public void FadeIn()
    {
        _hasFaded = false;
        Fade(1, 0);
    }

    public void FadeOut()
    {
        _hasFaded = false;
        Fade(0, 1);
    }

    public bool HasFaded()
    {
        Debug.Log(_hasFaded);
        return _hasFaded;
    }

    private void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    private IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer < FadeDuration)
        {
            _fadeColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / FadeDuration);
            _renderer.material.color = _fadeColor;
            
            timer += Time.deltaTime;
            yield return null;
        }

        _fadeColor.a = alphaOut;
        _renderer.material.color = _fadeColor;

        _hasFaded = true;
    }
}

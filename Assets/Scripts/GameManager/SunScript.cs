using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float rotateSpeed;
    public int moveSpeed;
    private bool stopMove = false;
    public SpriteRenderer sprite;
    public GameObject SunPos;
    void Start()
    {

    }
    IEnumerator fadeOut(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        Color spriteColor = MyRenderer.material.color;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            Debug.Log(alpha);
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
    void Update()
    {
        if (stopMove == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            if (transform.position.y < -7)
            {
                Destroy(gameObject);
            }
            transform.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, SunPos.transform.position, Time.deltaTime * 5);
        }
    }
    public void FadeOutAndDie()
    {
        SunPos = GameObject.Find("SunPos");
        stopMove = true;
        gameObject.layer = 0;
        StartCoroutine(fadeOut(sprite, 5));
    }
}

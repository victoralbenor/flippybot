using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public UnityEvent onTrigger;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        onTrigger.Invoke();
    }
}
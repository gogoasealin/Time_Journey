using UnityEngine;

public class FallingObject : FallingPlatform
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !called)
        {
            Invoke("Fall", fallColdown);
            called = true;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

private float bulletSpeed = 50.0f;
public int bulletDamage = 5;
   
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
         StartCoroutine(bulletDespawn());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator bulletDespawn()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    
}

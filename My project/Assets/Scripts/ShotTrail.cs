using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrail : MonoBehaviour
{
    [SerializeField] float speed;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

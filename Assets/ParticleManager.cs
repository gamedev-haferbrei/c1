using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "ParticleManager";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        //var exp = GetComponent<ParticleSystem>();
        var main = exp.main;
        exp.Play();
        Destroy(gameObject, main.duration);
        //https://docs.unity3d.com/ScriptReference/ParticleSystem-main.html
        //https://docs.unity3d.com/2018.1/Documentation/Manual/PartSysExplosion.html
    }
}

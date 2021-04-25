using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    public static PostProcessManager instance;

    public Volume _volume;

    Vignette vignette;


    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<Volume>();
        Debug.Log(_volume.profile.name);
        vignette = (Vignette)_volume.profile.components[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vignette)
        {
            Debug.Log(_volume.profile.components[0].name);
        }
    }
}

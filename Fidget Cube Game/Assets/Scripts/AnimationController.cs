using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public GameObject logo;
    public GameObject logoPanel;
    public GameObject instructPanel;

    public float animSpeed = 0.01f;
    private bool justStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        logoPanel.SetActive(true);
        instructPanel.SetActive(false);
        logo.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // as time increases, increase logo size until it reaches original size
        if (logo.transform.localScale.x < 1)
        {
            logo.transform.localScale += new Vector3(animSpeed, animSpeed, animSpeed);
        }
        else
        {
            logo.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

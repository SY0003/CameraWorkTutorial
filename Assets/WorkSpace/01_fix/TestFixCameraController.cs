using System;
using System.Linq;
using UnityEngine;

public class TestFixCameraController : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private GameObject[] vcams = Array.Empty<GameObject>();

    private int currentCameraIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var vcam in this.vcams)
        {
            vcam.SetActive(false);
        }
        this.vcams[this.currentCameraIndex].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(this.key)) return;

        this.vcams[this.currentCameraIndex].SetActive(false);
        this.currentCameraIndex = (this.currentCameraIndex + 1) % this.vcams.Length;
        this.vcams[this.currentCameraIndex].SetActive(true);
    }
}

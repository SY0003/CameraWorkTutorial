using Cinemachine.PostFX;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TestFocusCameraController : MonoBehaviour
{
    [SerializeField] CinemachinePostProcessing cinemachinePostProcessing;

    [SerializeField] private float deltaValue = 10f;
    [SerializeField] private float maxValue = 3f;
    [SerializeField] private float minValue = 0.1f;

    [SerializeField] private KeyCode focusInKey;
    [SerializeField] private KeyCode focusOutKey;
    [SerializeField] private KeyCode resetKey;

    private DepthOfField depthOfField;
    private float initialFocalDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.depthOfField = cinemachinePostProcessing.m_Profile.GetSetting<DepthOfField>();
        this.initialFocalDistance = depthOfField.focusDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.focusInKey))
        {
            this.depthOfField.focusDistance.value = Mathf.Clamp(this.depthOfField.focusDistance.value - this.deltaValue * Time.deltaTime, this.minValue, this.maxValue);
        }

        if (Input.GetKey(this.focusOutKey))
        {
            this.depthOfField.focusDistance.value = Mathf.Clamp(this.depthOfField.focusDistance.value + this.deltaValue * Time.deltaTime, this.minValue, this.maxValue);
        }

        if (Input.GetKeyDown(this.resetKey))
        {
            this.depthOfField.focusDistance.value = this.initialFocalDistance;
        }
    }
}
using System.Collections;
using UnityEngine;

// Moves lense when using only keyboard controls
public class LensAnimator : MonoBehaviour
{
    // Circles for cool effect
    const float SPEED_1 = 1f;
    const float SPEED_2 = 0.3f;
    const float SPEED_3 = 0.75f;

    public Transform coolCircle1;
    public Transform coolCircle2;
    public Transform coolCircle3;

    // Movement
    float largeScale = 1f;
    const float SHRINK_SPEED = 1;
    const float SMOOTHNESS = 10;
    const float LENS_DIST_FROM_PLAYER = 8;

    Vector2 goToPosition;
    Vector2 eyeLoc = new Vector2(0, 2.4f);
    float goToScale = 0;

    InputMaster lensControls;

    bool fullVision;

    #region Setting inputs

    // Initializes variables
    private void Awake()
    {
        lensControls = new InputMaster();
        lensControls.Lens.LensMovement.performed += ctx => MoveLens(ctx.ReadValue<Vector2>());
        lensControls.Lens.LensMovement.canceled += ctx => ReturnLens();
        lensControls.Lens.Enable();
    }

    // Disables inputs when object disabled
    private void OnDisable() { lensControls.Lens.Disable(); }

    #endregion

    // Set-up
    private void Start()
    {
        transform.localPosition = eyeLoc;
        transform.localScale = Vector3.zero;
        StartCoroutine(RotateCircles());
        StartCoroutine(LensMover());
    }

    /* Moves lens to inputted position
     * @param lensDirection inputted position to move lens to
     */
    void MoveLens(Vector2 lensDirection)
    {
        goToPosition = (Vector3)lensDirection * LENS_DIST_FROM_PLAYER;
        goToScale = largeScale;
    }

    // Returns lens to idle position
    void ReturnLens()
    {
        goToPosition = eyeLoc;
        goToScale = 0;
    }

    public void SetLensSize(float lensSize)
    {
        largeScale = lensSize;
    }

    public void FullVisionTrue()
    {
        fullVision = true;
        lensControls.Lens.Disable();
        transform.localScale = Vector2.one * 9999;
        transform.localPosition = Vector2.zero;
    }

    // Animates lens shrinking and moving smoothly
    IEnumerator LensMover()
    {
        while (!fullVision)
        {
            transform.localPosition = goToPosition + ((Vector2)transform.localPosition - goToPosition) / SMOOTHNESS * (SMOOTHNESS - 1);
            goToScale = Mathf.Clamp(goToScale - SHRINK_SPEED / 100.0f, 0, largeScale);
            transform.localScale = Vector3.one * (goToScale + (transform.localScale.x - goToScale) / SMOOTHNESS * (SMOOTHNESS - 1));
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    // Rotates cool circles for the cool effect
    IEnumerator RotateCircles()
    {
        while (!fullVision)
        {
            coolCircle1.Rotate(Vector3.forward, SPEED_1);
            coolCircle2.Rotate(Vector3.forward, SPEED_2);
            coolCircle3.Rotate(Vector3.forward, SPEED_3);
            yield return null;
        }
    }
}

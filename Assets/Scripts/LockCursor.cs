using Unity.VisualScripting;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    public bool cursorLock = true;

    // Update is called once per frame
    void Update()
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
                cursorLock = false;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
                cursorLock = true;
        }
    }
}

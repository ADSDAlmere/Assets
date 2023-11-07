using UnityEngine;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour
{
    [Header("Application quit values:")]
    [Tooltip("This is the exit button.")]
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("The king left the building....");
        Application.Quit();
    }
}

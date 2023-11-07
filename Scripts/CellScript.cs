using UnityEngine;

public class CellScript : MonoBehaviour
{
    [Header("CellScript values:")]
    [Tooltip("Left wall")]
    [SerializeField]
    public GameObject wallL;
    [Tooltip("Right wall")]
    [SerializeField]
    public GameObject wallR;
    [Tooltip("Upper wall")]
    [SerializeField]
    public GameObject wallU;
    [Tooltip("Lower wall")]
    [SerializeField]
    public GameObject wallD;
}
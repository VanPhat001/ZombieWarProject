using UnityEngine;

public abstract class BaseLayout : MonoBehaviour
{
    [SerializeField] protected GameObject _layout;
    public GameObject Layout => _layout;

    public virtual void OpenLayout()
    {
        Layout.SetActive(true);
    }

    public virtual void CloseLayout()
    {
        Layout.SetActive(false);
    }

    public void SetLayoutActive(bool active = true)
    {
        Layout.SetActive(active);
    }
}
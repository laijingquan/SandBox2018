using System;
using UnityEngine;

public class RefreshGalleryWrapper : MonoBehaviour
{
    private void RefreshGallery(string path)
    {
        AndroidJavaClass class2 = new AndroidJavaClass("com.astricstore.androidutil.AndroidGallery");
        object[] args = new object[] { path };
        class2.CallStatic("RefreshGallery", args);
    }

    private void SetGalleryPath()
    {
        string name = "CaptureAndSave";
        CaptureAndSave save = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
        if (save != null)
        {
            name = save.gameObject.name;
        }
        AndroidJavaClass class2 = new AndroidJavaClass("com.astricstore.androidutil.AndroidGallery");
        object[] args = new object[] { name };
        class2.CallStatic("SetGalleryPath", args);
    }

    private void Start()
    {
        this.SetGalleryPath();
        this.StoragePermissionRequest();
    }

    private void StoragePermissionRequest()
    {
        string name = "CaptureAndSave";
        CaptureAndSave save = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
        if (save != null)
        {
            name = save.gameObject.name;
        }
        AndroidJavaClass class2 = new AndroidJavaClass("com.astricstore.androidutil.AndroidGallery");
        object[] args = new object[] { name };
        class2.CallStatic("CheckForPermission", args);
    }
}


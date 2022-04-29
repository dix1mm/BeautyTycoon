using UnityEngine;
using UnityEditor;

public static class StaticEditor{

    [MenuItem("BeautyTycoon/Update sprites rotation")]
    public static void UpdateSpritesRotation(){
        var camera = Camera.main;
        var sprites = GameObject.FindObjectsOfType<SpriteRenderer>();
        foreach (var sprite in sprites)
            sprite.transform.rotation = camera.transform.rotation;
    }
}
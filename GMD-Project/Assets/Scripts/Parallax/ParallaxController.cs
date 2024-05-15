using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Sprite[] parallaxSprites;
        [SerializeField] private float parallaxSpeed;
        [SerializeField] private float repeatThreshold;
        
        private readonly List<GameObject> _parallaxGameObjects = new();
        private void Start()
        {
            for (var i = 0; i < parallaxSprites.Length; i++)
            {
                var parallaxGameObject = new GameObject($"ParallaxLayer{i + 1}");
                
                var spriteRenderer = parallaxGameObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = parallaxSprites[i];
                spriteRenderer.sortingLayerName = "Background";
                spriteRenderer.drawMode = SpriteDrawMode.Tiled;
                spriteRenderer.size = new Vector2(100, 26);
                
                parallaxGameObject.transform.position = new Vector3(0, 0, i);
                parallaxGameObject.transform.SetParent(transform);
                
                _parallaxGameObjects.Add(parallaxGameObject);
            }
        }
        
        private void Update()
        {
            // Make parent follow camera
            transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
            
            // Adjust position of parallax layers relative to parent object
            for (var i = 0; i < _parallaxGameObjects.Count; i++)
            {
                var parallaxOffset = ((transform.position.x * (parallaxSpeed * (_parallaxGameObjects.Count - i)) + repeatThreshold) % (repeatThreshold * 2) - repeatThreshold) * -1;
                _parallaxGameObjects[i].transform.localPosition = new Vector3(parallaxOffset, 0, _parallaxGameObjects[i].transform.position.z);
            }
        }
    }
}

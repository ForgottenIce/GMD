using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Sprite[] parallaxSprites;
        [SerializeField] private float parallaxSpeedX = 0.08f;
        [SerializeField] private float parallaxSpeedY = 0.01f;
        [SerializeField] private float cameraOffsetY = 2f;
        [SerializeField] private float repeatThreshold = 18f;

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
            // Adjust position of parallax layers relative to parent object
            for (var i = 0; i < _parallaxGameObjects.Count; i++)
            {
                var parallaxOffsetX = ((transform.position.x * (parallaxSpeedX * (_parallaxGameObjects.Count - i)) + repeatThreshold) % (repeatThreshold * 2) - repeatThreshold) * -1;
                var parallaxOffsetY = transform.position.y * (parallaxSpeedY * (_parallaxGameObjects.Count - i)) * -1 + cameraOffsetY;
                _parallaxGameObjects[i].transform.localPosition = new Vector3(parallaxOffsetX, parallaxOffsetY, _parallaxGameObjects[i].transform.position.z);
            }
        }
    }
}

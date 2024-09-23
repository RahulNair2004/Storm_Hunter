using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles; // Array of tiles manually placed in the row
    public float unsafeTileProbability = 0.5f; // 50% chance for a tile to be unsafe

    void Start()
    {
        RandomizeTiles();
    }

    void RandomizeTiles()
    {
        foreach (GameObject tile in tiles)
        {
            // Randomly decide whether a tile is safe or unsafe
            bool isUnsafe = Random.value < unsafeTileProbability;

            if (isUnsafe)
            {
                // If the tile is unsafe, enable the CollapsingTile script
                tile.AddComponent<CollapsingTile>();
                tile.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                tile.GetComponent<Renderer>().material.color = Color.green;
                // If the tile is safe, make sure it has no collapsing behavior
                CollapsingTile collapsingTile = tile.GetComponent<CollapsingTile>();
                if (collapsingTile != null)
                {
                    Destroy(collapsingTile); // Ensure no collapsing script on safe tiles
                }
            }
        }
    }
}

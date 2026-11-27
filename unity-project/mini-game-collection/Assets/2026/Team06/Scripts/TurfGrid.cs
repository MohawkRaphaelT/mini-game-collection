using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MiniGameCollection.Games2026.Team06
{
    public class TurfGrid : MiniGameBehaviour
    {
        [SerializeField] private Tilemap floor;            
        [SerializeField] private ScoreKeeper scoreKeeper;  
        [SerializeField] private Color player1Color = new Color(1f, 0.5f, 0.5f);
        [SerializeField] private Color player2Color = new Color(0.5f, 0.6f, 1f);

        public void Paint(Vector3 worldPosition, PlayerID player, int radius = 0)
        {
            Vector3Int center = floor.WorldToCell(worldPosition);
          
          // AI used for this equation
          for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    if (x * x + y * y > radius * radius) continue;

                    PaintCell(new Vector3Int(center.x + x, center.y + y, 0), player);
                }
            }
        }

        private void PaintCell(Vector3Int cell, PlayerID player)
        {
            if (!floor.HasTile(cell)) return;

            Color oneColor = player1Color;
            Color twoColor = player2Color;
            PlayerID otherPlayer = PlayerID.Player2;
            if (player == PlayerID.Player2)
            {
                oneColor = player2Color;
                twoColor = player1Color;
                otherPlayer = PlayerID.Player1;
            }

            Color current = floor.GetColor(cell);

            if (current == oneColor)
                return;
            if (current == twoColor)
                scoreKeeper.AddScore(otherPlayer, -1);

            scoreKeeper.AddScore(player, 1);
            floor.SetTileFlags(cell, TileFlags.None);
            floor.SetColor(cell, oneColor);
        }

    }
}


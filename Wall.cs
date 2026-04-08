using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Wall {
		public Wall(Vector2 pos1, Vector2 pos2, float height, Color color, int portal) {
			this.edge[0] = pos1; this.edge[1] = pos2;
			this.height = height;
			this.color = color;
			this.portal = portal;
		}

		public Vector2[] edge = new Vector2[2];

		public bool[] onScreen = new bool[2];

		public int portal = -1;

		public float height;
		public Color color;
	}
}

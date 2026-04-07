using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Wall {
		public Wall(Vector2 pos1, Vector2 pos2, float height, Color color) {
			this.edge[0] = pos1; this.edge[1] = pos2;
			this.height = height;
			this.color = color;
		}

		public Vector2[] edge = new Vector2[2];

		public float[] distance = new float[2];

		public float height;
		public Color color;
	}
}

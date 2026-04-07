using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer {
	public class Wall {
		public Wall(Vector2 pos1, Vector2 pos2, float height, Color color) {
			this.edge1 = pos1; this.edge2 = pos2;
			this.height = height;
			this.color = color;
		}

		public Vector2 edge1;
		public Vector2 edge2;

		public float height;
		public Color color;
	}
}

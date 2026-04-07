using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Player {
		public Player(Vector2 position) {
			this.position = position;
		}

		public Vector2 position;

		public float heading = 0;

		public float FOV = MathF.PI / 3;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Renderer;

namespace DoomRenderer {
	public class Level {
		public Level(int level) {
			this.level = level;
		}

		private int level;

		public List<Sector> sectors = new List<Sector>();

		public void LoadLevel() {
			sectors.Clear();

			sectors.Add(new Sector());

			sectors[0].walls.Add(new Wall(new Vector2(1.0f, 1.0f), new Vector2(2.0f, 1.0f), 10, Color.Red));
		} 
	}
}

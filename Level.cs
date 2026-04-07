using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
			sectors[0].walls.Add(new Wall(new Vector2(1.0f, 0.0f), new Vector2(1.0f, 2.0f), 10, Color.Red));
			sectors[0].walls.Add(new Wall(new Vector2(1.0f, 2.0f), new Vector2(0.0f, 2.5f), 10, Color.Red));
		} 
	}
}

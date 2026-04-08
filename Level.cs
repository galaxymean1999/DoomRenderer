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

			sectors.Add(new Sector(0));
			sectors[0].walls.Add(new Wall(new Vector2(0.0f, 6.0f), new Vector2(2.0f, 4.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(2.0f, 4.0f), new Vector2(6.0f, 4.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(6.0f, 4.0f), new Vector2(8.0f, 6.0f), 10, Color.Red, 1));
			sectors[0].walls.Add(new Wall(new Vector2(8.0f, 6.0f), new Vector2(8.0f, 8.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(8.0f, 8.0f), new Vector2(6.0f, 10.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(6.0f, 10.0f), new Vector2(2.0f, 10.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(2.0f, 10.0f), new Vector2(0.0f, 8.0f), 10, Color.Red, -1));
			sectors[0].walls.Add(new Wall(new Vector2(0.0f, 8.0f), new Vector2(0.0f, 6.0f), 10, Color.Red, -1));

			sectors.Add(new Sector(1));
			sectors[1].walls.Add(new Wall(new Vector2(6.0f, 4.0f), new Vector2(10.0f, 2.0f), 10, Color.Red, -1));
			sectors[1].walls.Add(new Wall(new Vector2(10.0f, 2.0f), new Vector2(12.0f, 4.0f), 10, Color.Red, 2));
			sectors[1].walls.Add(new Wall(new Vector2(12.0f, 4.0f), new Vector2(8.0f, 6.0f), 10, Color.Red, -1));
			sectors[1].walls.Add(new Wall(new Vector2(8.0f, 6.0f), new Vector2(6.0f, 4.0f), 10, Color.Red, 0));

			sectors.Add(new Sector(2));
			sectors[2].walls.Add(new Wall(new Vector2(10.0f, 2.0f), new Vector2(12.0f, 0.0f), 10, Color.Red, -1));
			sectors[2].walls.Add(new Wall(new Vector2(12.0f, 0.0f), new Vector2(14.0f, 2.0f), 10, Color.Red, -1));
			sectors[2].walls.Add(new Wall(new Vector2(14.0f, 2.0f), new Vector2(12.0f, 4.0f), 10, Color.Red, -1));
			sectors[2].walls.Add(new Wall(new Vector2(12.0f, 4.0f), new Vector2(10.0f, 2.0f), 10, Color.Red, 1));
		} 
	}
}

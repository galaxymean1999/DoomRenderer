using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DoomRenderer {
	public class GameState {
		public GameState() {
			player = new Player(new Vector2(0, 0.5f));

			level = new Level(0);
			level.LoadLevel();
		}

		public Player player;

		public Level level;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Sector {
		public Sector(int id) {
			walls = new List<Wall>();

			this.id = id;
		}

		public int id;

		public List<Wall> walls;
	}
}

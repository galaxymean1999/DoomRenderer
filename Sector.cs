using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer {
	public class Sector {
		public Sector() {
			walls = new List<Wall>();
		}

		public List<Wall> walls;
	}
}

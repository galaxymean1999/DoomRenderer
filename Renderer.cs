using DoomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer {
	public class Renderer {
		public Renderer(Level lvl) {
			this.lvl = lvl;
		}

		private Level lvl;

		public void DrawWalls() {
			foreach (Sector sec in lvl.sectors) {
				foreach (Wall wall in sec.walls) {
					
				}
			}
		}
	}
}

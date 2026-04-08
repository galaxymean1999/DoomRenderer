using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Renderer {
		public Renderer(GameState gs, Size clientSize) {
			this.gs = gs;
			this.ClientSize = clientSize;

			focalLength = (ClientSize.Width / 2) / MathF.Tan(gs.player.FOV / 2);
		}

		private GameState gs;

		private Size ClientSize;

		private float focalLength;

		private float NormaliseAngle(float a) {
			if (a < -MathF.PI) {
				return a + 2 * MathF.PI;
			}
			else if (a > MathF.PI) {
				 return a - 2 * MathF.PI;
			}
			else {
				return a;
			}
		}

		public void DrawSector(Graphics g, Sector s) {
			foreach (Wall wall in s.walls) {
				Rectangle[] wallStripe = new Rectangle[2];

				//
				// Draw wall edges
				//
				for (int i = 0; i < 2; i++) {
					float dx = wall.edge[i].X - gs.player.position.X;
					float dy = wall.edge[i].Y - gs.player.position.Y;

					float distance = MathF.Sqrt(dx * dx + dy * dy);

					float angleToPlayer = MathF.PI / 2 + gs.player.heading + MathF.Atan(dx / dy);

					if (wall.edge[i].Y > gs.player.position.Y) {
						dy = gs.player.position.Y - wall.edge[i].Y;
						dx = gs.player.position.X - wall.edge[i].X;

						angleToPlayer = -MathF.PI / 2 + gs.player.heading + MathF.Atan(dx / dy);
					}
						
					angleToPlayer = NormaliseAngle(angleToPlayer);

					float ry = MathF.Cos(angleToPlayer) * distance;
					float rx = MathF.Sin(angleToPlayer) * distance;

					int screenX = (int)(ClientSize.Width / 2 + rx / ry * focalLength);
							
					int wallHeight = (int)(ClientSize.Height / ry);

					int screenY = ClientSize.Height / 2 - wallHeight / 2;

					wallStripe[i] = new Rectangle(screenX, screenY, 1, wallHeight);

					if (ry > 0 && screenX > 0 && screenX < ClientSize.Width) {
						if (angleToPlayer <= gs.player.FOV / 2 && angleToPlayer >= gs.player.FOV / -2) {
							g.FillRectangle(Brushes.White, wallStripe[i]);

							wall.onScreen[i] = true;
						}
					}
					else {
						wall.onScreen[i] = false;
					}
				}

				//
				// Fill the space between the edges
				//
				if (wall.onScreen[0] || wall.onScreen[1]) {
					Rectangle start = wallStripe[wallStripe[1].X > wallStripe[0].X ? 0 : 1];
					Rectangle end = wallStripe[wallStripe[1].X > wallStripe[0].X ? 1 : 0];

					for (int x = start.X + 1; x < end.X - 1; x++) {
						
					}
				}
			}
		}

		public void DrawMinimap(Graphics g) {
			foreach (Sector s in gs.level.sectors) {
				foreach (Wall wall in s.walls) {
					for (int i = 0; i < 2; i++) {
						g.FillRectangle(Brushes.White, wall.edge[i].X * 10 + 20, wall.edge[i].Y * 10 + 20, 2, 2);
					}
				}
			}

			g.FillRectangle(Brushes.Red, gs.player.position.X * 10 + 20, gs.player.position.Y * 10 + 20, 2, 2);
			g.DrawLine(Pens.Red, gs.player.position.X * 10 + 20, gs.player.position.Y * 10 + 20, (gs.player.position.X * 10 + MathF.Cos(gs.player.heading) * 10) + 20, (gs.player.position.Y * 10 + MathF.Sin(gs.player.heading) * 10) + 20);
		}
	}
}

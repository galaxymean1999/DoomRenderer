using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoomRenderer {
	public class Renderer {
		public Renderer(GameState gs, Size clientSize) {
			this.gs = gs;
			this.ClientSize = clientSize;
		}

		private GameState gs;

		private Size ClientSize;

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

		private void CalculateDistances() {
			foreach (Sector s in gs.level.sectors) {
				foreach (Wall wall in s.walls) {
					for (int i = 0; i < 2; i++) {
						wall.distance[i] = MathF.Sqrt(MathF.Pow(gs.player.position.X - wall.edge[i].X, 2) + MathF.Pow(gs.player.position.Y - wall.edge[i].Y, 2));
					}
				}
			}
		}

		public void DrawWalls(Graphics g) {
			CalculateDistances();

			foreach (Sector s in gs.level.sectors) {
				foreach (Wall wall in s.walls) {
					Rectangle[] wallStripe = new Rectangle[2];

					//
					// Draw wall edges
					//
					for (int i = 0; i < 2; i++) {
						float dx = wall.edge[i].X - gs.player.position.X;
						float dy = wall.edge[i].Y - gs.player.position.Y;

						float angleToPlayer = MathF.PI / 2 + gs.player.heading + MathF.Atan(dx / dy);

						if (wall.edge[i].Y > gs.player.position.Y) {
							dy = gs.player.position.Y - wall.edge[i].Y;
							dx = gs.player.position.X - wall.edge[i].X;

							angleToPlayer = -MathF.PI / 2 + gs.player.heading + MathF.Atan(dx / dy);
						}
						
						angleToPlayer = NormaliseAngle(angleToPlayer);

						float ry = MathF.Cos(angleToPlayer) * wall.distance[i];
						float rx = MathF.Sin(angleToPlayer) * wall.distance[i];

						int screenX = (int)MathF.Abs(((angleToPlayer - gs.player.FOV / 2) / gs.player.FOV * ClientSize.Width));
							
						int wallHeight = (int)(ClientSize.Height / wall.distance[i]);

						int screenY = ClientSize.Height / 2 - wallHeight / 2;

						wallStripe[i] = new Rectangle(screenX, screenY, 1, wallHeight);

						if (ry > 0) {
							if (angleToPlayer <= gs.player.FOV / 2 && angleToPlayer >= gs.player.FOV / -2) {
								g.FillRectangle(Brushes.White, wallStripe[i]);
							}
						}		
					}

					//
					// Fill the space between the edges
					//
					float dheight = MathF.Abs((float)wallStripe[0].Height - wallStripe[1].Height) / 2.0f;

					int startScreenX = wallStripe[wallStripe[1].X > wallStripe[0].X ? 0 : 1].X;
					int endScreenX = wallStripe[wallStripe[1].X > wallStripe[0].X ? 1 : 0].X;

					int widthToFill = (int)MathF.Abs(wallStripe[0].X - wallStripe[1].X);
					
					float heightStep = dheight / widthToFill;
					
					if (gs.player.position.X > wall.edge[0].X) {
						heightStep *= -1;
					}

					int step = 0;
					for (int x = startScreenX + 1; x < endScreenX - 1; x++) {
						int wallHeight = 0;

						if (wallStripe[1].Height > wallStripe[0].Height) {
							wallHeight = (int)(wallStripe[1].Height - heightStep * step * 2);
						}
						else {
							wallHeight = (int)(wallStripe[0].Height - heightStep * step * 2);
						}

						int y = (int)(ClientSize.Height / 2 - wallHeight / 2);

						if (x >= 0) {
							g.FillRectangle(Brushes.Red, x, y, 1, wallHeight);
						}
						
						step++;
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
		}
	}
}

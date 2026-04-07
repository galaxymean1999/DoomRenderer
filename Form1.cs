namespace DoomRenderer
{
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			gs = new GameState();

			renderer = new Renderer(gs, ClientSize);

			this.DoubleBuffered = true;
		}

		private List<Keys> keys = new List<Keys>();

		private GameState gs;

		private Renderer renderer;

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (!keys.Contains(e.KeyCode)) {
				keys.Add(e.KeyCode);
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			keys.Remove(e.KeyCode);
		}

		private void Draw(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.Clear(Color.Black);

			renderer.DrawWalls(g);

			renderer.DrawMinimap(g);
		}

		private void Update(object sender, EventArgs e) {
			if (keys.Contains(Keys.Left)) {
				gs.player.heading -= 0.04f;
			}
			else if (keys.Contains(Keys.Right)) {
				gs.player.heading += 0.04f;
			}

			if (keys.Contains(Keys.Up)) {
				gs.player.position.X += MathF.Cos(gs.player.heading) * 0.3f;
				gs.player.position.Y += MathF.Sin(gs.player.heading) * 0.3f;
			}

			if (keys.Contains(Keys.Down)) {
				gs.player.position.X -= MathF.Cos(gs.player.heading) * 0.3f;
				gs.player.position.Y -= MathF.Sin(gs.player.heading) * 0.3f;
			}

			if (keys.Contains(Keys.Escape)) {
				this.Close();
			}

			this.Invalidate();
		}
	}
}

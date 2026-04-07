namespace DoomRenderer
{
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private List<Keys> keys = new List<Keys>();

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


		}

		private void Update(object sender, EventArgs e) {

		}
	}
}

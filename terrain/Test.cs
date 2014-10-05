using System;
using System.Drawing;
using System.Windows.Forms;

namespace terrain
{
    internal class Test
    {
        [STAThread]
        private static void Main()
        {
            Console.Out.WriteLine("Doing shit");
            Terrain.Generate();
            Console.Out.WriteLine("Done shit");
        }

        public static void Show(Image img)
        {
            var frm = new Form
            {
                ClientSize = new Size(800, 800),
                BackColor = Color.Black,
                WindowState = FormWindowState.Maximized
            };
            PictureBox pic;
            frm.Controls.Add(pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = img,
                SizeMode = PictureBoxSizeMode.Zoom
            });
            pic.DoubleClick += (sender, e) => { Clipboard.SetImage(img); };
            frm.ShowDialog();
        }
    }
}
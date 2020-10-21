using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplayViewer
{
    public class Note
    {
        public PictureBox Graphic;
        private Size window;
        private int yLoc;

        public Note(Point p, Form f)
        {
            Graphic = new PictureBox
            {
                Size = new Size(30, 15),
                BackColor = Color.Red,
                Location = p
            };
            if (Graphic.Location.Y > window.Height || Graphic.Location.Y < 0)
                Graphic.Enabled = false;
            //f.Controls.Add(Graphic);
            window = f.ClientSize;
        }

        public void Move (int deltaY)
        {
            yLoc = Graphic.Location.Y + deltaY;

            if (yLoc > window.Height || yLoc < 0)
                if (Graphic.Enabled)
                    Graphic.Enabled = false;
            else
                if (!Graphic.Enabled)
                    Graphic.Enabled = true;
            // this is real slow, buddy
            Graphic.Location = new Point(Graphic.Location.X, yLoc);
        }
    }
}

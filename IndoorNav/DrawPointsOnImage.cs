using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNav
{
    public class DrawPointsOnImage
    {
        public static Image Draw(List<Point> data, Image source)
        {
            Image img = source;

            Graphics g = Graphics.FromImage(img);


            PointF lastP = new PointF(-1, -1);
            foreach(var i in data)
            {
                PointF pf = GetXYinPix(i, img);

                if (lastP.X == -1)
                    lastP = pf;
                Pen redPen = new Pen(Brushes.Red, 5);
                g.DrawEllipse(redPen, new Rectangle((int)pf.X, (int)pf.Y, 3, 3));
                g.DrawLine(redPen, lastP.X, lastP.Y, pf.X, pf.Y);
                lastP = pf;

            }
            g.DrawImage(img,new System.Drawing.Point(0,0));

            img.Save("img.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            return img;
        }

        private static System.Drawing.PointF GetXYinPix(Point pn, Image source)
        {
            float Y0 = 0;
            float X0 = source.Width;

            float YMax = source.Height;
            float XMax = 0;

            float widthm = 21;
            float heightm = 4.6f;

            float multiplierX = source.Width / widthm;
            float multiplierY = source.Height / heightm;

            PointF pfr = new PointF();

            pfr.X = X0 - (float)(pn.X * multiplierX);
            pfr.Y = Y0 + (float)(pn.Y * multiplierY);

            return pfr;
        }
    }
}

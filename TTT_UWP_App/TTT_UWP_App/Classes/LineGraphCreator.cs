using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;

//Daan Bergmans
//3AONc
//PXL-IT
namespace TTT_UWP_App.Classes
{
    public class LineGraphCreator
    {

        private int[] coords;

        //Constructor
        public LineGraphCreator(int[] coords)
        {
            this.coords = coords;
        }

        //Verandert 4 ints (is 1 lijn met 2 coordinaten) in de lijst coords
        public void changeLine(int[] coords, int lijnNummer)
        {
            for (int i = 0; i <= 4; i++)
            {
                this.coords[((lijnNummer - 1) * 4) + 1] = coords[i];
            }
        }

        //Maakt van de coordinaten in array coords line objecten die in de list lines gezet worden en geeft dit terug
        public List<Line> createLines()
        {

            List<Line> lines = new List<Line>();

            for (int i = 0; i <= coords.Count() / 4; i += 4)
            {
                Line line = new Line();
                line.X1 = coords[i];
                line.Y1 = coords[i + 1];
                line.X2 = coords[i + 2];
                line.Y2 = coords[i + 3];

                lines.Add(line);
            }

            return lines;

        }

        /*
        public List<Line> createXAxis(Point startpoint, int length, int scale)
        {

            List<Line> lines = new List<Line>();

            //As
            Line line = new Line();
            line.X1 = startpoint.X;
            line.Y1 = startpoint.Y;
            line.X2 = line.X1 + length;
            line.Y2 = line.Y1;

            lines.Add(line);

            if(length % scale == 0)
            {
                return lines;
            }

            //Streepjes op as
            for(int i = 0; i <= length / scale; i++)
            {
                line = new Line();
                //Moet nog bijkomen
            }

        }*/
    }
}

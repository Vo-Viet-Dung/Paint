using System;

public class EventMouse
{
    private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        //set it to mouse down, illustrate the shape being drawn and reset the last position
        IsPainting = true;
        ShapeNum++;
        LastPos = new Point(0, 0);
    }
    protected void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        //PAINTING
        if (IsPainting)
        {
            //check it's not at the same place it was last time, 
            //saves on recording more data.
            if (LastPos != e.Location)
            {
                //set this position as the last position
                LastPos = e.Location;
                //store the position, width, colour and shape relation data
                DrawingShapes.NewShape(LastPos, CurrentWidth,
                    CurrentColour, ShapeNum);
            }
        }
        //refresh the panel so it will be forced to re-draw.
        panel1.Refresh();
    }
    private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (IsPainting)
        {
            //Finished Painting.
            IsPainting = false;
        }
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        //Apply a smoothing mode to smooth out the line.
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //DRAW THE LINES
        for (int i = 0; i < DrawingShapes.NumberOfShapes() - 1; i++)
        {
            Shape T = DrawingShapes.GetShape(i);
            Shape T1 = DrawingShapes.GetShape(i + 1);
            //make sure shape the two adjoining shape numbers are part of the same shape
            if (T.ShapeNumber == T1.ShapeNumber)
            {
                //create a new pen with its width and colour
                Pen p = new Pen(T.Colour, T.Width);
                p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                //draw a line between the two adjoining points
                e.Graphics.DrawLine(p, T.Location, T1.Location);
                //get rid of the pen when finished
                p.Dispose();
            }
        }
    }
}

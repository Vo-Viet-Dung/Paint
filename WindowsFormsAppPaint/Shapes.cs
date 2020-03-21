using System;

public class Shapes
{
    private List _Shapes;    //Stores all the shapes

    public Shapes()
    {
        _Shapes = new List();
    }
    //Returns the number of shapes being stored.
    public int NumberOfShapes()
    {
        return _Shapes.Count;
    }
    //Add a shape to the database, recording its position,
    //width, colour and shape relation information
    public void NewShape(Point L, float W, Color C, int S)
    {
        _Shapes.Add(new Shape(L, W, C, S));
    }
    //returns a shape of the requested data.
    public Shape GetShape(int Index)
    {
        return _Shapes[Index];
    }
    //Removes any point data within a certain threshold of a point.
    public void RemoveShape(Point L, float threshold)
    {
        for (int i = 0; i < _Shapes.Count; i++)
        {
            //Finds if a point is within a certain distance of the point to remove.
            if ((Math.Abs(L.X - _Shapes[i].Location.X) < threshold) &&
                (Math.Abs(L.Y - _Shapes[i].Location.Y) < threshold))
            {
                //removes all data for that number
                _Shapes.RemoveAt(i);

                //goes through the rest of the data and adds an extra
                //1 to defined them as a separate shape and shuffles on the effect.
                for (int n = i; n < _Shapes.Count; n++)
                {
                    _Shapes[n].ShapeNumber += 1;
                }
                //Go back a step so we don't miss a point.
                i -= 1;
            }
        }
    }
}

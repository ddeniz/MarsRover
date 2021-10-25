using Core.Interface;
using System;

namespace Core
{
    public class Position : IPosition
    {
        private IPoint _point;
        public IPlateau Plateau { get; set; }
        public Position(Point point, IPlateau plateau)
        {
            if (!IsPositionValid(point,plateau))
            {
                throw new IndexOutOfRangeException("pls fit in plateau max and min x,y");
            }
            _point = point;
            Plateau = plateau;
        }


        public bool SetPoint(IPoint point)
        {
            if (IsPositionValid(point, this.Plateau))
            {
                _point = point;
                return true;
            }
            return false;


        }

        public IPoint GetPoint()
        {
            return this._point;

        }

        private bool IsPositionValid(IPoint point, IPlateau plateau)
        {
            return plateau.MinX <= point.X && point.X <= plateau.MaxX && plateau.MinY <= point.X && point.Y <= plateau.MaxyY;
            
        }
    }

}

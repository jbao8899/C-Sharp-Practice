using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Box
    {
        private int _length; // all boxes have a length of 3 by default
        private int _height;
        private int _width;

        public Box(int setLength, int setHeight, int setWidth)
        {
            _length = setLength;
            _height = setHeight;
            _width = setWidth;
        }

        // Can make property that does not correspond to private member variable.
        //public int MyProperty { get; set; }

        // Properties for each private member variable
        public int Length
        {
            get { return _length;  }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Length must be positive.");
                }
                else
                {
                    _length = value;
                }
            }
        }

        public int Height
        {
            get { return _height;  }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Height must be positive.");
                }
                else
                {
                    _height= value;
                }
            }
        }

        public int Width
        {
            get { return _width;  }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Width must be positive.");
                }
                else
                {
                    _width= value;
                }
            }
        }

        // Does not correspond to a specific member variable
        public int Volume
        {
            get
            {
                return _length * _height * _width;
            }
        }

        // Does not correspond to a specific member variable
        public int FrontSurface
        {
            get
            {
                return _height * _length;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"This box has a length of {_length}, a height of {_height}, and a width of {_width}, so the volume is {_length * _height * _width}");
        }

        // Setters and getters below
        public void SetLength(int setLength)
        {
            if (setLength <= 0)
            {
                throw new Exception("Length must be positive.");
            }
            _length = setLength;
        }

        public int GetLength()
        {
            return _length;
        }

        public void SetHeight(int setHeight)
        {
            if (setHeight <= 0)
            {
                throw new Exception("Height must be positive.");
            }
            _height = setHeight;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetWidth(int setWidth)
        {
            if (setWidth <= 0)
            {
                throw new Exception("Width must be positive.");
            }
            _width = setWidth;
        }

        public int GetWidth()
        {
            return _width;
        }


    }
}

namespace MathLibrary
{
    /// <summary>
    /// An object containing two floats.
    /// </summary>
    public struct Vector2
    {
        private float _x;
        private float _y;

        /// <summary>
        /// The first value of the vector.
        /// </summary>
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// The second value of the vector.
        /// </summary>
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <param name="x"> The first value of the vector. </param>
        /// <param name="y"> The second value of the vector. </param>
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

    }
}
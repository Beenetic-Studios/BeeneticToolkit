namespace BeeneticToolkit.Random {

    /// <summary>
    /// Manages a global instance of a random number generator, providing centralized access
    /// and control across the application.
    /// </summary>
    public static class RngManager {
        private static RandomGenerator _current;

        /// <summary>
        /// Gets or sets the global random number generator instance.
        /// </summary>
        public static RandomGenerator Current {
            get { return _current; }
            set { _current = value; }
        }

        static RngManager() {
            _current = RngFactory.GetGenerator();
        }
    }
}
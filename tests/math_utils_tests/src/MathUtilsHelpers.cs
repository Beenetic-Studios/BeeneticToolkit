using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.MathUtils {

    [TestClass]
    public class MathUtilsHelpers {

        #region Tolerance Values

        internal const float FLOAT_TOLERANCE = 1E-6f;
        internal const double DOUBLE_TOLERANCE = 1E-12d;
        internal const decimal DECIMAL_TOLERANCE = 1E-24m;

        #endregion Tolerance Values
    }
}
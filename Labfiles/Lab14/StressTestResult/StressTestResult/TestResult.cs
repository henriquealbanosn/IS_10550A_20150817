using System;

namespace StressTestResult
{
    /// <summary>
    /// Struct that models the result of a stress test for girders.
    /// <para>
    /// A stress test contains the following information:
    /// <list type="bullet">
    /// <item>
    /// TestDate: The date and time that the test was conducted.
    /// </item>
    /// <item>
    /// Temperature: The temperature, in K, at which the test was performed.
    /// </item>
    /// <item>
    /// AppliedStress: The stress, in kN, applied to the girder.
    /// </item>
    /// <item>
    /// Deflection: The resulting deflection, in mm, of the mid-point of the girder.
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    [Serializable]
    public struct TestResult : IComparable<TestResult>
    {
        /// <summary>
        /// Compare stress test results based on the recorded deflection.
        /// </summary>
        /// <param name="other">
        /// The stress test result to compare against.
        /// </param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// If this.Deflection &lt; other.Deflection, then -1.
        /// </item>
        /// <item>
        /// If this.Deflection &eq; other.Deflection, then 0.
        /// </item>
        /// <item>
        /// If this.Deflection &gt; other.Deflection, then 1.
        /// </item>
        /// </list>
        /// </returns>
        public int CompareTo(TestResult other)
        {
            int result = 0;

            if (this.Deflection < other.Deflection)
            {
                result = -1;
            }

            if (this.Deflection == other.Deflection)
            {
                result = 0;
            }

            if (this.Deflection > other.Deflection)
            {
                result = 1;
            }

            return result;
        }

        /// <summary>
        /// The date and time that the test was conducted.
        /// </summary>
        public DateTime TestDate { get; set; }
        
        /// <summary>
        /// The temperature, in K, at which the stress test was performed.
        /// <para>
        /// This value cannot be negative.
        /// </para>
        /// </summary>
        private short temperature;
        public short Temperature
        {
            get
            {
                return this.temperature;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be less than zero");
                }
                else
                {
                    this.temperature = value;
                }
            }
        }

        /// <summary>
        /// The stress applied to the girder, in kN.
        /// <para>
        /// This value cannot be negative.
        /// </para>
        /// </summary>
        private short appliedStress;
        public short AppliedStress
        {
            get
            {
                return this.appliedStress;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Applied stress cannot be less than zero");
                }
                else
                {
                    this.appliedStress = value;
                }
            }
        }

        /// <summary>
        /// The resulting deflection of the girder, in mm.
        /// <para>
        /// This value cannot be negative.
        /// </para>
        /// </summary>
        private short deflection;
        public short Deflection
        {
            get
            {
                return this.deflection;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Deflection cannot be less than zero");
                }
                else
                {
                    this.deflection = value;
                }
            }
        }
    }
}

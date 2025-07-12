namespace TheBearDev.Ursinity.Runtime.Time
{
    /// <summary>
    /// Represents a stopwatch utility used for measuring elapsed time.
    /// </summary>
    public class Stopwatch
    {
        #region Constructor

        /// <summary>
        /// Represents a stopwatch utility used for measuring elapsed time.
        /// </summary>
        public Stopwatch(long duration)
        {
            durationInMilliseconds = duration;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the stopwatch has been started and is currently running.
        /// </summary>
        /// <value>
        /// True if the stopwatch is running; otherwise, false.
        /// </value>
        public bool IsStarted
        {
            get => timer.IsRunning;
        }

        /// <summary>
        /// Gets the total duration specified for the stopwatch, in milliseconds.
        /// </summary>
        /// <value>
        /// The total duration in milliseconds as a read-only value.
        /// </value>
        // ReSharper disable once MemberCanBePrivate.Global
        public long DurationInMilliseconds
        {
            get => durationInMilliseconds;
        }

        /// <summary>
        /// Gets the duration specified for the stopwatch in seconds.
        /// </summary>
        /// <value>
        /// The duration of the stopwatch in seconds, derived from the duration in milliseconds.
        /// </value>
        public long DurationInSeconds
        {
            get => DurationInMilliseconds / 1000;
        }

        #endregion Properties

        #region Fields

        private readonly System.Diagnostics.Stopwatch timer = new();
        private readonly long durationInMilliseconds;

        #endregion Fields

        // =================================================================================

        #region Methods

        /// <summary>
        /// Starts the stopwatch to begin measuring elapsed time.
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stops the stopwatch and halts the measurement of elapsed time.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// Restarts the stopwatch by stopping, resetting, and then starting it again.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public void Restart()
        {
            timer.Stop();
            timer.Reset();
            timer.Start();
        }

        /// <summary>
        /// Determines whether the elapsed time of the stopwatch is greater than the specified duration.
        /// </summary>
        /// <returns>
        /// Returns true if the elapsed time exceeds the duration; otherwise, false.
        /// </returns>
        public bool IsElapsed()
        {
            return timer.ElapsedMilliseconds > DurationInMilliseconds;
        }

        /// <summary>
        /// Checks if the elapsed time of the stopwatch exceeds the specified duration,
        /// and resets the stopwatch if the condition is met.
        /// </summary>
        /// <returns>
        /// Returns true if the elapsed time exceeds the specified duration and the stopwatch is reset; otherwise, false.
        /// </returns>
        public bool CheckAndReset()
        {
            if (timer.ElapsedMilliseconds <= DurationInMilliseconds)
            {
                return false;
            }

            Restart();

            return true;
        }

        #endregion Methods
    }
}
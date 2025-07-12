namespace TheBearDev.Ursinity.Runtime.Time
{
    /// <summary>
    /// The PomodoroTimer class provides a utility for implementing a timer
    /// based on the Pomodoro technique, allowing the measurement
    /// and control of elapsed time within a specified duration.
    /// </summary>
    public class PomodoroTimer
    {
        #region Constructor

        /// <summary>
        /// Represents a timer implementing the Pomodoro technique, offering functionality
        /// to manage and check elapsed time within a specified duration.
        /// </summary>
        public PomodoroTimer(long duration)
        {
            durationInMilliseconds = duration;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the timer has been started and is currently running.
        /// </summary>
        /// <value>
        /// Returns true if the timer is running; otherwise, false.
        /// </value>
        public bool IsStarted
        {
            get => timer.IsRunning;
        }


        /// <summary>
        /// Gets the duration of the timer in milliseconds.
        /// </summary>
        /// <value>
        /// Returns the total duration of the timer as a 64-bit integer value in milliseconds.
        /// </value>
        public long DurationInMilliseconds
        {
            get => durationInMilliseconds;
        }


        /// <summary>
        /// Gets the duration of the timer in seconds.
        /// </summary>
        /// <value>
        /// The duration in seconds, derived by converting the millisecond duration to seconds.
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
        /// Initiates the timer, starting the measurement of elapsed time from the current moment.
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stops the timer, pausing the measurement of elapsed time without resetting it.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
        }


        /// <summary>
        /// Resets the timer to its initial state and immediately starts measuring elapsed time from zero.
        /// </summary>
        public void Restart()
        {
            timer.Stop();
            timer.Reset();
            timer.Start();
        }


        /// <summary>
        /// Determines whether the elapsed time of the timer has exceeded the specified duration, returning a boolean result.
        /// </summary>
        /// <returns>
        /// True if the elapsed time exceeds the specified duration; otherwise, false.
        /// </returns>
        public bool IsElapsed()
        {
            return timer.ElapsedMilliseconds > DurationInMilliseconds;
        }


        /// <summary>
        /// Checks if the timer has exceeded the specified duration and resets the timer
        /// if the duration is exceeded.
        /// </summary>
        /// <returns>
        /// Returns true if the elapsed time exceeds the specified duration and the timer
        /// is reset; otherwise, returns false.
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
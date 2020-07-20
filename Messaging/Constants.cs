namespace BigJacob.Messaging
{
    /// <summary>
    /// Constants used by the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Host name for an Outlook server
        /// </summary>
        public const string OutlookHost = "smtp.office365.com";

        /// <summary>
        /// Host name for a Gmail server
        /// </summary>
        public const string GoogleHost = "smtp.gmail.com";

        /// <summary>
        /// Port for an Outlook server
        /// </summary>
        public const int OutlookPort = 587;

        /// <summary>
        /// Port for a Gmail server
        /// </summary>
        public const int GooglePort = 587;
    }
}
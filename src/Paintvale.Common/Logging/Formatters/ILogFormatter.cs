namespace Paintvale.Common.Logging.Formatters
{
    interface ILogFormatter
    {
        string Format(LogEventArgs args);
    }
}

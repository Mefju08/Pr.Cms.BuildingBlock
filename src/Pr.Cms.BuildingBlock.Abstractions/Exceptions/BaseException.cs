namespace Pr.Cms.BuildingBlock.Abstractions.Exceptions
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa dla wszystkich wyjątków aplikacyjnych w systemie.
    /// Umożliwia spójne zarządzanie błędami i automatyczne mapowanie na kody HTTP.
    /// </summary>
    public abstract class BaseException(string message) : Exception(message)
    {
    }
}

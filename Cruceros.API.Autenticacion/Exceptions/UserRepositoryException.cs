﻿namespace Cruceros.API.Autenticacion.Exceptions;

[Serializable]
internal class UserRepositoryException : Exception
{
    public UserRepositoryException()
    {
    }

    public UserRepositoryException(string? message) : base(message)
    {
    }

    public UserRepositoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
﻿using System.Runtime.Serialization;

namespace ManagementService.Domain.Contracts.Exceptions;
[Serializable]
public class BusinessRuleValidationException : Exception
{
    private readonly IBaseBusinessRule _rule;

    public BusinessRuleValidationException(IBaseBusinessRule rule)
    {
        _rule = rule;
    }

    public BusinessRuleValidationException(string? message, IBaseBusinessRule rule) : base(message)
    {
        _rule = rule;
    }

    public BusinessRuleValidationException(string? message, Exception? innerException, IBaseBusinessRule rule) : base(message, innerException)
    {
        _rule = rule;
    }

    protected BusinessRuleValidationException(SerializationInfo info, StreamingContext context, IBaseBusinessRule rule) : base(info, context)
    {
        _rule = rule;
    }
}
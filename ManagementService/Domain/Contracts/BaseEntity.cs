﻿using ManagementService.Domain.Contracts.Exceptions;

namespace ManagementService.Domain.Contracts;

public abstract class BaseEntity
{
    private readonly Queue<IBaseDomainEvent> _events = new Queue<IBaseDomainEvent>();

    public int CountEvents => _events.Count;

    protected void AddDomainEvent(IBaseDomainEvent domainDomainEvent)
    {
        _events.Enqueue(domainDomainEvent);
    }

    protected static void CheckRule(IBaseBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    public IBaseDomainEvent DequeueEvent()
    {
        return _events.Dequeue();
    }
}
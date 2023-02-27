﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncKeyedLock;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.DistributedLocking;

public class LocalAbpDistributedLock : IAbpDistributedLock, ISingletonDependency
{
    private readonly AsyncKeyedLocker<string> _localSyncObjects = new(o =>
    {
        o.PoolSize = 20;
        o.PoolInitialFill = 1;
    });
    protected IDistributedLockKeyNormalizer DistributedLockKeyNormalizer { get; }

    public LocalAbpDistributedLock(IDistributedLockKeyNormalizer distributedLockKeyNormalizer)
    {
        DistributedLockKeyNormalizer = distributedLockKeyNormalizer;
    }
    
    public async Task<IAbpDistributedLockHandle> TryAcquireAsync(
        string name,
        TimeSpan timeout = default,
        CancellationToken cancellationToken = default)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        var key = DistributedLockKeyNormalizer.NormalizeKey(name);

        var timeoutReleaser = await _localSyncObjects.LockAsync(key, timeout, cancellationToken);
        if (!timeoutReleaser.EnteredSemaphore)
        {
            return null;
        }
        return new LocalAbpDistributedLockHandle(timeoutReleaser);
    }
}

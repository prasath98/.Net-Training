using Core.ViewModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstraction.ISoftLockService
{
    public interface ISoftLockService
    {
        Task<SoftLock?> GetSoftLock(int LockId);
        Task<SoftLock?> CreateSoftLock(SoftLockDto softLock);
        Task<SoftLock?> UpdateSoftLock(SoftLockDto softLock);
        Task<SoftLock?> DeleteSoftLock(int LockId);
    }
}

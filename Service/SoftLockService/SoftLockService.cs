using Core.Abstraction.ISoftLockService;
using Core.ViewModel;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SoftLockService
{
    public class SoftLockService:ISoftLockService
    {
        private readonly EmployeeDbContext _dbContext;

        public SoftLockService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SoftLock?> GetSoftLock(int LockId)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == LockId);
            return result ?? null;
        }

        public async Task<SoftLock?> CreateSoftLock(SoftLockDto softLock)
        {
            var result = new SoftLock();
            if (softLock != null)
            {
                result.EmployeeId = softLock.Employee_id;
                result.Status = softLock.Status;
                result.Manager = softLock.Manager;
                result.ManagerStatus = softLock.ManagerStatus;
                result.RequestDate = softLock.ReqDate;
                result.LastUpdated = softLock.Lastupdated;
                result.RequestMessage = softLock.ReqMessage;
                result.Wfmremark = softLock.WfmRemark;
                result.MgrStatuscomment = softLock.MgrStatusComment;
                result.LastUpdated = softLock.Lastupdated;
                await _dbContext.SoftLocks.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<SoftLock?> UpdateSoftLock(SoftLockDto softLock)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == softLock.LockId);
            if (result != null)
            {
                result.LockId = softLock.LockId;
                result.EmployeeId = softLock.Employee_id;
                result.Status = softLock.Status;
                result.Manager = softLock.Manager;
                result.ManagerStatus = softLock.ManagerStatus;
                result.RequestDate = softLock.ReqDate;
                result.LastUpdated = softLock.Lastupdated;
                result.RequestMessage = softLock.ReqMessage;
                result.Wfmremark = softLock.WfmRemark;
                result.MgrStatuscomment = softLock.MgrStatusComment;
                result.LastUpdated = softLock.Lastupdated;
                _dbContext.SoftLocks.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new SoftLock();
        }

        public async Task<SoftLock?> DeleteSoftLock(int LockId)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == LockId);
            if (result != null)
            {
                _dbContext.SoftLocks.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new SoftLock();
        }
    }
}

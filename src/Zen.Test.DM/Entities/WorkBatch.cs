using System;
using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class WorkBatch : DomainEntity<int>
    {
        public virtual int NocProcId { get; set; }//[ProcID]
        public virtual string BatchType { get; set; }
        public virtual string ClientMasterShortName { get; set; }         
        public virtual DateTime? CompletedDate { get; set; }
        public virtual DateTime? SplitDate { get; set; }

        //sets
        public virtual ISet<WorkPlacement> PlxRecords { get; set; }
        public virtual ISet<WorkMaintenance> MaintRecords { get; set; }
        

        #region Methods

        public virtual void AddPlacement(WorkPlacement item)
        {
            if (PlxRecords == null) PlxRecords = new HashSet<WorkPlacement>();
            item.Batch = this;
            PlxRecords.Add(item);
        }
        public virtual void RemovePlacement(WorkPlacement item)
        {
            if (PlxRecords == null || !PlxRecords.Contains(item)) return;
            item.Batch = null;
            PlxRecords.Remove(item);
        }

        public virtual void AddMaintenence(WorkMaintenance item)
        {
            if (MaintRecords == null) MaintRecords = new HashSet<WorkMaintenance>();
            item.Batch = this;
            MaintRecords.Add(item);
        }
        public virtual void RemoveMaintenance(WorkMaintenance item)
        {
            if (MaintRecords == null || !MaintRecords.Contains(item)) return;
            item.Batch = null;
            MaintRecords.Remove(item);
        }

        #endregion
    }
}
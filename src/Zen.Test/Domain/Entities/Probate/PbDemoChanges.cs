using System;

namespace Zen.Test.Domain.Entities.Probate
{
    public class PbDemoChanges : DemoChanges
    {
        #region Properties
               
        public virtual PbAccount Account { get; set; }
        public override Debtor Debtor
        {
            get { return Account.Debtor; }
        }

        public virtual string Relation { get; set; }
        public override DebtorRelation Relationship
        {
            get
            {
                switch (Relation.ToUpper().Trim())
                {
                        //case "DEBTOR"
                    case "DECEASED":
                        return new DebtorRelation {Id = "DECEASED", MailToCode = 'D'};
                    case "ATTORNEY":
                        return new DebtorRelation {Id = "ATTORNEY", MailToCode = 'A'};
                    case "EXECUTOR":
                        return new DebtorRelation {Id = "EXECUTOR", MailToCode = 'E'};
                    case "FAMILY":
                        return new DebtorRelation {Id = "FAMILY", MailToCode = 'F'};
                    default:
                        throw new Exception("Unknown Relationship!");
                }
            }
        }

        #endregion
    }
}
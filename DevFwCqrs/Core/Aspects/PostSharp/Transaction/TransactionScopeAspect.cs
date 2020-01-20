using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.PostSharp.Transaction
{
    [Serializable]
    public class TransactionScopeAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope();
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            var scope = ((TransactionScope)args.MethodExecutionTag);
            scope.Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}

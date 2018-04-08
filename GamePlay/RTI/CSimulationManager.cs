/********************************************
bdj 2017/2/15
联邦底板
*********************************************/
using System;
using RACoN;
namespace STK_demonstration
{
    public class CSimulationManager
    {
        #region things
        public RACoN.Federation.CFederationExecution federation;
        public CSTK_demonstration federate;
        public MFrm view;
        #endregion //things
        public CSimulationManager(MFrm fm)
        {
            view = fm;
            // Initialize the federation execution
            federation = new RACoN.Federation.CFederationExecution();
            federation.FederationExecutionName = "CoSimulationSystem";
            federation.FDD = @".\CoSimulationSystem.fed";
            // Initialize the application-specific federate
            federate = new CSTK_demonstration(this);
        }
    }
}

using System;
using RACoN;

namespace STK_demonstration.Som
{
    public class OpUserNum : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter UserNumValue;
        #endregion //Declarations

        #region Constructor
        public OpUserNum()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpUserNum";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // TheValue
            UserNumValue = new RACoN.RTILayer.CHlaInteractionParameter("UserNumValue");
            this.Parameters.Add(UserNumValue);
        }
        #endregion //Constructor
    }
}

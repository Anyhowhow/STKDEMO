using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class COpSimTimeIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter SimTime;
        #endregion //Declarations

        #region Constructor
        public COpSimTimeIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpSimTime";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;
            
            // Create Parameters
            // SimTime
            SimTime = new RACoN.RTILayer.CHlaInteractionParameter("SimTime");
            this.Parameters.Add(SimTime);
        }
        #endregion //Constructor
    }
}

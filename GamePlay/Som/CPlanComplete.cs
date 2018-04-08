using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class CPlanComplete : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter mc;
        #endregion //Declarations

        #region Constructor
        public CPlanComplete()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.PlanComplete";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // SimTime
            mc = new RACoN.RTILayer.CHlaInteractionParameter("MissionCompleted");
            this.Parameters.Add(mc);
        }
        #endregion //Constructor
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class OpFinishIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter Finish;
        public RACoN.RTILayer.CHlaInteractionParameter EndTime;
        #endregion //Declarations

        #region Constructor
        public OpFinishIC()
            : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.OpFinish";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // clear_path
            Finish = new RACoN.RTILayer.CHlaInteractionParameter("Finish");
            this.Parameters.Add(Finish);
            EndTime = new RACoN.RTILayer.CHlaInteractionParameter("EndTime");
            this.Parameters.Add(EndTime);
        }
        #endregion //Constructor
    }
}

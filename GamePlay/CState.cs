using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration
{
    public class CState
    {
        public WorkMode workMode;
        public bool isSceneSetUp = false;
        public double replayDataFaster=1.0;//可以在xml里直接指定读取回放数据的子线程的加快倍数，按钮toolStripButton_upReplayData和toolStripButton_downReplaData控制其大小

        public double stepTime;
        public string start_time;
        public string stop_time;

        public string defaultStartTime;
        public string defaultStopTime;
        public double defaultStepTime;//STK推进步长默认值0.017

        internal double rewindStkTime;//代表STK的启动时间

        public enum WorkMode
        {
            SimMode,
            ReplayMode,
        };
    }
}

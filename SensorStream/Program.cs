using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SCP;
using Microsoft.SCP.Topology;

namespace SensorStream
{
    [Active(true)]
    class Program : TopologyDescriptor
    {
        static void Main(string[] args)
        {
        }

        public ITopologyBuilder GetTopologyBuilder()
        {
            TopologyBuilder topologyBuilder = new TopologyBuilder("SensorStream" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            topologyBuilder.SetSpout(
                "Spout",
                Spout.Get,
                new Dictionary<string, List<string>>()
                {
                    {Constants.DEFAULT_STREAM_ID, new List<string>(){"count"}}
                },
                1);
            topologyBuilder.SetBolt(
                "Bolt",
                Bolt.Get,
                new Dictionary<string, List<string>>(),
                1).shuffleGrouping("Spout");

            return topologyBuilder;
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.SCP;
using Microsoft.SCP.Rpc.Generated;

namespace SensorStream
{
    public class Spout : ISCPSpout
    {
        private Context ctx;


        public Spout(Context ctx)
        {
            this.ctx = ctx;

            Dictionary<string, List<Type>> outputSchema = new Dictionary<string, List<Type>>();
            outputSchema.Add("default", new List<Type>() { typeof(DateTime),
typeof(string),
typeof(int) });
            this.ctx.DeclareComponentSchema(new ComponentStreamSchema(null, outputSchema));
        }

        public static Spout Get(Context ctx, Dictionary<string, Object> parms)
        {
            return new Spout(ctx);
        }

        public void NextTuple(Dictionary<string, Object> parms)
        {
            Values sensorReading = Sensor.GetSensorReading();
            ctx.Emit(Constants.DEFAULT_STREAM_ID, sensorReading);
        }

        public void Ack(long seqId, Dictionary<string, Object> parms)
        {

        }

        public void Fail(long seqId, Dictionary<string, Object> parms)
        {

        }
    }
}
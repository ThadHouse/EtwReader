using Microsoft.Performance.Toolkit.Engine;
using Microsoft.Performance.SDK.Extensibility;
using System;
using Microsoft.Performance.SDK.Extensibility.SourceParsing;
using Microsoft.Performance.SDK.Processing;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Tracing;

namespace EtwReader
{

    class Program
    {
        private static readonly Guid DataGuid = new Guid("ff15e657-4f26-570e-88ab-0796b258d11c");

        static void ParseEvent(TraceEvent data)
        {
            if (data.ProviderGuid == DataGuid)
            {
                // Parse data for DataGuid here
                ;
            }
        }

        static void Main(string[] args)
        {
            String etlFile;
            if (args.Length != 1)
            {
                etlFile = @"C:\Users\thhous\Desktop\withbatching\tput.etl";
            } else
            {
                etlFile = args[0];
            }


            using ETWTraceEventSource source = new ETWTraceEventSource(etlFile);

            source.Dynamic.All += ParseEvent;
            source.Process();
        }
    }
}

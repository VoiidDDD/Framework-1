using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.FrameworkFiles
{
    public class ComputeEngineConfiguration
    {
        private int instances;
        private string machineType;
        private string gpuType;
        private string ssdSize;
        private string region;
        public int Instances { get { return instances; } }
        public string MachineType { get { return machineType; } }
        public string GpuType { get {
                switch (gpuType)
                {
                    case "NVIDIA T4":
                        return "nvidia-tesla-t4";
                    case "NVIDIA V100":
                        return "nvidia-tesla-v100";
                    case "NVIDIA TESLA P4":
                        return "nvidia-tesla-p4";
                    case "NVIDIA TESLA P100":
                        return "nvidia-tesla-p100";
                    case "NVIDIA TESLA K80":
                        return "nvidia-tesla-k80";
                    default:
                        return "nvidia-tesla-v100";
                }
            } }
        public string SsdSize { get { return ssdSize.Substring(0, 1); } }
        public string Region { get { return region; } }
        public ComputeEngineConfiguration(IConfiguration config)
        {
            instances = int.Parse(config["TestConfiguration:instances"]);
            machineType = config["TestConfiguration:machineType"];
            gpuType = config["TestConfiguration:gpuType"];
            ssdSize = config["TestConfiguration:ssdSize"];
            region = config["TestConfiguration:region"];
        }
    }
}

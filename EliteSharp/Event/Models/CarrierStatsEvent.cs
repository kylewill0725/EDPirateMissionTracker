using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CarrierStatsEvent : EventBase
    {
        internal CarrierStatsEvent()
        {
        }

        [JsonProperty("CarrierID")] public long CarrierId { get; private set; }

        [JsonProperty("Callsign")] public string Callsign { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("DockingAccess")] public string DockingAccess { get; private set; }

        [JsonProperty("AllowNotorious")] public bool AllowNotorious { get; private set; }

        [JsonProperty("FuelLevel")] public long FuelLevel { get; private set; }

        [JsonProperty("JumpRangeCurr")] public double JumpRangeCurr { get; private set; }

        [JsonProperty("JumpRangeMax")] public double JumpRangeMax { get; private set; }

        [JsonProperty("PendingDecommission")] public bool PendingDecommission { get; private set; }

        [JsonProperty("SpaceUsage")] public SpaceUsageInfo SpaceUsage { get; private set; }

        [JsonProperty("Finance")] public FinanceInfo Finance { get; private set; }

        [JsonProperty("Crew")] public IReadOnlyList<CrewInfo> Crew { get; private set; }

        [JsonProperty("ShipPacks")] public IReadOnlyList<object> ShipPacks { get; private set; }

        [JsonProperty("ModulePacks")] public IReadOnlyList<object> ModulePacks { get; private set; }


        public class CrewInfo
        {
            internal CrewInfo()
            {
            }

            [JsonProperty("CrewRole")] public string CrewRole { get; private set; }

            [JsonProperty("Activated")] public bool Activated { get; private set; }

            [JsonProperty("Enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled { get; private set; }

            [JsonProperty("CrewName", NullValueHandling = NullValueHandling.Ignore)]
            public string CrewName { get; private set; }
        }

        public class FinanceInfo
        {
            internal FinanceInfo()
            {
            }

            [JsonProperty("CarrierBalance")] public long CarrierBalance { get; private set; }

            [JsonProperty("ReserveBalance")] public long ReserveBalance { get; private set; }

            [JsonProperty("AvailableBalance")] public long AvailableBalance { get; private set; }

            [JsonProperty("ReservePercent")] public long ReservePercent { get; private set; }

            [JsonProperty("TaxRate")] public long TaxRate { get; private set; }
        }

        public class SpaceUsageInfo
        {
            internal SpaceUsageInfo()
            {
            }

            [JsonProperty("TotalCapacity")] public long TotalCapacity { get; private set; }

            [JsonProperty("Crew")] public long Crew { get; private set; }

            [JsonProperty("Cargo")] public long Cargo { get; private set; }

            [JsonProperty("CargoSpaceReserved")] public long CargoSpaceReserved { get; private set; }

            [JsonProperty("ShipPacks")] public long ShipPacks { get; private set; }

            [JsonProperty("ModulePacks")] public long ModulePacks { get; private set; }

            [JsonProperty("FreeSpace")] public long FreeSpace { get; private set; }
        }
    }

    public partial class CarrierStatsEvent
    {
        public static CarrierStatsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierStatsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CarrierStatsEvent> CarrierStatsEvent;

    }
}
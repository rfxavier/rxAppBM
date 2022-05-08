﻿using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringMessage
    {
        public Guid BlueMeteringMessageId { get; set; }
        public double ParamsRxTime { get; set; }
        public int ParamsPort { get; set; }
        public bool ParamsDuplicate { get; set; }
        public long ParamsRadioGpsTime { get; set; }
        public double ParamsRadioDelay { get; set; }
        public int ParamsRadioDataRate { get; set; }
        public long ParamsRadioModulationBandwidth { get; set; }
        public string ParamsRadioModulationType { get; set; }
        public int ParamsRadioModulationSpreading { get; set; }
        public string ParamsRadioModulationCodeRate { get; set; }
        public int ParamsRadioHardwareStatus { get; set; }
        public int ParamsRadioHardwareChain { get; set; }
        public long ParamsRadioHardwareTmst { get; set; }
        public double ParamsRadioHardwareSnr { get; set; }
        public double ParamsRadioHardwareRssi { get; set; }
        public double ParamsRadioHardwareChannel { get; set; }
        public double ParamsRadioHardwareGpsLat { get; set; }
        public double ParamsRadioHardwareGpsLng { get; set; }
        public int ParamsRadioHardwareGpsAlt { get; set; }
        public double ParamsRadioTime { get; set; }
        public double ParamsRadioFrequency { get; set; }
        public int ParamsRadioSize { get; set; }
        public int ParamsCounterUp { get; set; }
        public bool ParamsLoraHeaderClassB { get; set; }
        public bool ParamsLoraHeaderConfirmed { get; set; }
        public bool ParamsLoraHeaderAdr { get; set; }
        public bool ParamsLoraHeaderAck { get; set; }
        public bool ParamsLoraHeaderAdrAckReq { get; set; }
        public int ParamsLoraHeaderVersion { get; set; }
        public int ParamsLoraHeaderType { get; set; }
        public string ParamsPayload { get; set; }
        public string ParamsEncryptedPayload { get; set; }
        public string MetaNetwork { get; set; }
        public string MetaPacketHash { get; set; }
        public string MetaApplication { get; set; }
        public string MetaDeviceAddr { get; set; }
        public double MetaTime { get; set; }
        public string MetaDevice { get; set; }
        public string MetaPacketId { get; set; }
        public string MetaGateway { get; set; }
        public string Type { get; set; }




    }
}
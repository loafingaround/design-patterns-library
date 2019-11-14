﻿namespace MediatorPattern.Colleagues
{
    public class Boeing737200 : Aircraft
    {
        public Boeing737200(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }

        public override int Ceiling { get; }
    }
}
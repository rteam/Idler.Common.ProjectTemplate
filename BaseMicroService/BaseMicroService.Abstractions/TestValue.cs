using System;
using Idler.Common.Core.Domain;

namespace BaseMicroService.Abstractions
{
    public class TestValue : EntityWithGuidNoTrace
    {
        public string Name { get; set; }
    }
}
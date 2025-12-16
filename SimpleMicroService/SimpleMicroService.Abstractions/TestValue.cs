using System;
using Idler.Common.Core.Domain;

namespace SimpleMicroService.Abstractions
{
    public class TestValue : EntityWithGuidNoTrace
    {
        public string Name { get; set; }
    }
}
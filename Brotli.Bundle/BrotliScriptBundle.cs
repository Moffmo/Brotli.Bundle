using System;
using System.Web.Optimization;

namespace Brotli.Bundle
{
    /// <summary>
    ///     Script Bundle that will use Brotli Encoding/Compression
    /// </summary>
    public class BrotliScriptBundle : BrotliBundle
    {
        public BrotliScriptBundle(string virtualPath) : base(virtualPath)
        {
            BaseDefault();
        }

        public BrotliScriptBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath,
            transforms)
        {
            BaseDefault();
        }

        public BrotliScriptBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath)
        {
            BaseDefault();
        }

        public BrotliScriptBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(
            virtualPath, cdnPath, transforms)
        {
            BaseDefault();
        }

        private void BaseDefault()
        {
            ConcatenationToken = ";" + Environment.NewLine;
        }
    }
}
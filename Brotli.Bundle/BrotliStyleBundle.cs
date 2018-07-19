using System.Web.Optimization;

namespace Brotli.Bundle
{
    /// <summary>
    ///     Style Bundle that will use Brotli Encoding/Compression
    /// </summary>
    public class BrotliStyleBundle : BrotliBundle
    {
        public BrotliStyleBundle(string virtualPath) : base(virtualPath)
        {
        }

        public BrotliStyleBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath, transforms)
        {
        }

        public BrotliStyleBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath)
        {
        }

        public BrotliStyleBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(virtualPath, cdnPath, transforms)
        {
        }
    }
}
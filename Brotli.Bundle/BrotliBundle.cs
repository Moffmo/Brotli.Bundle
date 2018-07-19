using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Brotli.Bundle
{
    /// <summary>
    ///     Bundle that will use Brotli Encoding/Compression
    /// </summary>
    public class BrotliBundle : GzipBundle.GzipBundle
    {
        private const string AcceptEncodingHeader = "Accept-Encoding";
        private const string ContentEncodingHeader = "Content-Encoding";
        private const string BrotliShort = "br";
        private const string BrotliLong = "brotli";

        public BrotliBundle(string virtualPath) : base(virtualPath)
        {
        }

        public BrotliBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath, transforms)
        {
        }

        public BrotliBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath)
        {
        }

        public BrotliBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(
            virtualPath, cdnPath, transforms)
        {
        }

        public override BundleResponse CacheLookup(BundleContext context)
        {
            if (context != null)
                if (CheckHttpContext(context.HttpContext))
                {
                    HttpResponseBase response = context.HttpContext.Response;
                    if (RequestHasBrotliEncoding(context.HttpContext.Request) && !ResponseIsAlreadyEncoded(response))
                    {
                        response.Filter = new BrotliStream(response.Filter, CompressionMode.Compress);
                        response.AddHeader(ContentEncodingHeader, BrotliShort);
                    }
                }

            return base.CacheLookup(context);
        }

        private bool RequestHasBrotliEncoding(HttpRequestBase httpContextRequest)
        {
            return AcceptEncodingContains(httpContextRequest, BrotliShort, BrotliLong);
        }

        private static bool AcceptEncodingContains(HttpRequestBase request, params string[] encodingStrings)
        {
            var acceptEncodings = request.Headers.Get(AcceptEncodingHeader)?.ToLower();
            return !string.IsNullOrEmpty(acceptEncodings) &&
                   encodingStrings.Any(encodingString => acceptEncodings.Contains(encodingString.ToLower()));
        }

        private static bool ResponseIsAlreadyEncoded(HttpResponseBase httpResponse)
        {
            return httpResponse.Filter is BrotliStream;
        }

        private static bool CheckHttpContext(HttpContextBase httpContext)
        {
            return httpContext?.Request != null;
        }
    }
}
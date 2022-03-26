using api.Response;
using System.Collections.Generic;

namespace api.Interface
{
    public interface IQrcodesService
    {
        PostmarkerQRcodeResponse Postmarker(PostmarkerQRcodeRequest model);
    }
}

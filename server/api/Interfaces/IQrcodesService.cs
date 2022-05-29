using api.Response;
namespace api.Interface
{
    public interface IQrcodesService
    {
        PostmarkerQRcodeResponse Postmarker(PostmarkerQRcodeRequest model);
    }
}
